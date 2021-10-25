using EzD.Model;
using EzD_App.Data;
using EzD_App.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.DataAccess.Impliments
{
    public class DeliveryProposalDBAccess : IDeliveryProposalDBAccess
    {
        readonly ApplicationDbContext _dbContext;
        public DeliveryProposalDBAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddDeliveryProposal(string userId, DeliveryProposal deliveryProposal,int packageId)
        {
            User user = _dbContext.User.Include(u => u.IdentityUser).Include(u => u.DeliveryGuy).
                SingleOrDefault(u => u.IdentityUser.Id.Equals(userId));
            Package package = _dbContext.Packages.Include(package => package.FromAddress)
                .Include(package => package.ToAddress).Include(package => package.Owner)
                .SingleOrDefault(package => package.PackageID == packageId);

            if (user == null || package == null)
            {
                return false;
            }

            deliveryProposal.IntrestedDeliveryGuy = user.DeliveryGuy;
            deliveryProposal.Package = package;

            _dbContext.DeliveryProposals.Add(deliveryProposal);
            return SaveDbChanges();
        }

        public List<DeliveryProposal> GetDeliveryProposalsForPackage(int packageId)
        {
            return _dbContext.DeliveryProposals.Include(dp => dp.IntrestedDeliveryGuy).Include(dp => dp.Package).
                Include(dp => dp.Package.FromAddress).Include(dp => dp.Package.ToAddress).
                Include(dp => dp.Package.Owner).Where(dp => dp.Package.PackageID == packageId).ToList();
        }

        public Dictionary<int, User> GetAllUsersByDeliveryGuyId(List<DeliveryProposal> deliveryProposals)
        {
            Dictionary<int, User> usersByDeliveryGuyId = new();

            foreach (DeliveryProposal deliveryProposal in deliveryProposals)
            {
                User user = _dbContext.User.Include(user => user.DeliveryGuy).Include(user => user.IdentityUser).
                    SingleOrDefault(user => user.DeliveryGuy.DeliveryGuyID ==
                    deliveryProposal.IntrestedDeliveryGuy.DeliveryGuyID);

                if (user != null && user.DeliveryGuy.Active)
                {
                    usersByDeliveryGuyId.Add(user.DeliveryGuy.DeliveryGuyID, user);
                }
            }

            return usersByDeliveryGuyId;
        }

        public bool DeleteDeliveryProposal(int deliveryProposalId)
        {
            DeliveryProposal deliveryProposal = _dbContext.DeliveryProposals
                .Include(dp => dp.IntrestedDeliveryGuy).Include(dp => dp.Package)
                .Include(dp => dp.Package.FromAddress).Include(dp => dp.Package.ToAddress)
                .SingleOrDefault(dp => dp.ProposalID.Equals(deliveryProposalId));

            if (deliveryProposal == null)
            {
                return false;
            }

            _dbContext.DeliveryProposals.Remove(deliveryProposal);
            return SaveDbChanges();
        }

        public List<DeliveryProposal> GetDeliveryProposalsByUser(string userId)
        {
            User user = _dbContext.User.Include(u => u.IdentityUser).Include(u => u.DeliveryGuy)
                .SingleOrDefault(u => u.IdentityUser.Id.Equals(userId));

            if (user == null)
            {
                return null;
            }

            return _dbContext.DeliveryProposals.Include(dp => dp.IntrestedDeliveryGuy).Include(dp => dp.Package)
                .Include(dp => dp.Package.FromAddress).Include(dp => dp.Package.ToAddress)
                .Where(dp => dp.IntrestedDeliveryGuy.DeliveryGuyID == user.DeliveryGuy.DeliveryGuyID &&
                dp.Package.Status == Status.Pending).ToList();
        }

        private bool SaveDbChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
