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
    public class ApprovedDeliveryDBAccess : IApprovedDeliveryDBAccess
    {
        readonly ApplicationDbContext _dbContext;
        public ApprovedDeliveryDBAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ApprovedDelivery> GetApprovedDeliveries(string userId)
        {
            User user = _dbContext.User.Include(u => u.IdentityUser).Include(u=> u.DeliveryGuy)
                .SingleOrDefault(u => u.IdentityUser.Id.Equals(userId));

            if (user == null)
            {
                return null;
            }

            return _dbContext.ApprovedDelivery.Include(ad => ad.ChosenDeliveryGuy)
                .Include(ad => ad.Package).Include(ad => ad.Package.Owner)
                .Include(ad => ad.Package.FromAddress).Include(ad => ad.Package.ToAddress)
                .Where(ad => ad.ChosenDeliveryGuy.DeliveryGuyID == user.DeliveryGuy.DeliveryGuyID &&
                ad.Package.Status == Status.InProgress).ToList();
        }

        public bool ApproveDeliveryProposal(ApprovedDelivery approvedDelivery)
        {
           Package package = _dbContext.Packages.Include(p => p.Owner).Include(p => p.FromAddress).
                Include(p => p.ToAddress).SingleOrDefault(p => p.PackageID == approvedDelivery.Package.PackageID);
           DeliveryGuy deliveryGuy = _dbContext.DeliveryGuy.
               SingleOrDefault(d => d.DeliveryGuyID == approvedDelivery.ChosenDeliveryGuy.DeliveryGuyID);

            if (package == null || deliveryGuy == null)
            {
                return false;
            }

            package.Status = Status.InProgress;

            approvedDelivery.Package = package;
            approvedDelivery.ChosenDeliveryGuy = deliveryGuy;

            _dbContext.ApprovedDelivery.Add(approvedDelivery);
            return SaveDbChanges();
        }

        public bool AddDeliveryRank(int rank, int packageId)
        {
            Package package = _dbContext.Packages.Include(p => p.Owner).Include(p => p.FromAddress)
                .Include(p => p.ToAddress).SingleOrDefault(p => p.PackageID == packageId);
            ApprovedDelivery approvedDelivery = _dbContext.ApprovedDelivery.Include(d => d.ChosenDeliveryGuy)
                .SingleOrDefault(d => d.Package.PackageID == packageId);

            if (approvedDelivery == null)
            {
                return false;
            }

            float previousRank = approvedDelivery.ChosenDeliveryGuy.NumberOfVotes * approvedDelivery.ChosenDeliveryGuy.Rank;
            float newRank = (previousRank + rank) / (approvedDelivery.ChosenDeliveryGuy.NumberOfVotes + 1);

            if (newRank < 0 || newRank > 10)
            {
                return false;
            }

            approvedDelivery.ChosenDeliveryGuy.NumberOfVotes++;
            approvedDelivery.ChosenDeliveryGuy.Rank = newRank;
            approvedDelivery.RankScore = rank;

            return SaveDbChanges();
        }

        public List<ApprovedDelivery> GetAllVotes(string userId)
        {
            User user = _dbContext.User.Include(u => u.IdentityUser)
                .SingleOrDefault(d => d.IdentityUser.Id.Equals(userId));

            if (user == null)
            {
                return null;
            }

            return _dbContext.ApprovedDelivery.Include(ad => ad.Package)
                .Include(ad => ad.Package.FromAddress).Include(ad => ad.Package.ToAddress)
                .Include(ad => ad.ChosenDeliveryGuy).Include(ad => ad.Package.Owner)
                .Where(ad => ad.Package.Owner.UserID == user.UserID && ad.RankScore != null).ToList();
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
