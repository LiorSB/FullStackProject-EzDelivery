using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EzD.Model;
using EzD_App.Data;
using EzD_App.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EzD_App.DataAccess
{
    public class PackageDBAccess : IPackageDBAccess
    {
        readonly ApplicationDbContext _dbContext;
        public PackageDBAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddPackage(Package package, string userId)
        {
            User user = GetUser(userId);

            if (user == null)
            {
                return false;
            }

            package.Owner = user;

            _dbContext.Packages.Add(package);
            return SaveDbChanges();
        }

        public List<Package> GetAllPendingPackages(string userId)
        {   
            return _dbContext.Packages.Include(package => package.FromAddress)
                .Include(package => package.ToAddress).Include(package => package.Owner.IdentityUser)
                .Where(package => package.Status == Status.Pending && package.Owner.IdentityUser.Id != userId).ToList();
        }

        public List<Package> GetAllDonePackagesDelivered(string userId)
        {
            User user = GetUser(userId);

            if (user == null)
            {
                return null;
            }

            List<ApprovedDelivery> ApprovedDeliveries = _dbContext.ApprovedDelivery
                .Include(approvedDelivery => approvedDelivery.Package)
                .Where(approvedDelivery => approvedDelivery.ChosenDeliveryGuy.DeliveryGuyID ==
                user.DeliveryGuy.DeliveryGuyID).ToList();

            List<Package> packages = new();

            foreach (ApprovedDelivery approvedDelivery in ApprovedDeliveries)
            {
               Package package = _dbContext.Packages.Include(r => r.FromAddress)
                    .Include(r => r.ToAddress).Include(r => r.Owner).Include(r => r.Owner.IdentityUser)
                    .SingleOrDefault(s => s.Status == Status.Done && s.PackageID == approvedDelivery.Package.PackageID);

                if (package != null)
                {
                    packages.Add(package);
                }           
            }

            return packages;
        }

        public Package GetPackage(int packageId)
        {
            return _dbContext.Packages.Include(package => package.FromAddress)
                .Include(package => package.ToAddress)
                .SingleOrDefault(package => package.PackageID == packageId);
        }

        public List<Package> GetAllPackages(string userId)
        {
            User user = GetUser(userId);

            if (user == null)
            {
                return null;
            }

            return _dbContext.Packages.Include(package => package.FromAddress)
                .Include(package => package.ToAddress)
                .Where(package => package.Owner.UserID == user.UserID).ToList();
        }

        public bool ChangePackageDetails(Package editedPackage)
        {
            Package packageToEdit = _dbContext.Packages.SingleOrDefault(package => package.PackageID == editedPackage.PackageID);

            if (packageToEdit == null)
            {
                return false;
            }

            packageToEdit.SenderPhone = editedPackage.SenderPhone;
            packageToEdit.ContactPhone = editedPackage.ContactPhone;
            packageToEdit.Weight = editedPackage.Weight;
            packageToEdit.Description = editedPackage.Description;
            packageToEdit.PickUpDate = editedPackage.PickUpDate;
            packageToEdit.DeadLineDate = editedPackage.DeadLineDate;
            packageToEdit.FromAddress = editedPackage.FromAddress;
            packageToEdit.ToAddress = editedPackage.ToAddress;
            packageToEdit.Price = editedPackage.Price;
            packageToEdit.SenderIsReceiver = editedPackage.SenderIsReceiver;

            return SaveDbChanges();
        }
        
        public bool DeletePackage(int packageId)
        {
            Package package = _dbContext.Packages.Include(package => package.FromAddress).
                Include(package => package.ToAddress).SingleOrDefault(package => package.PackageID == packageId);  

            if (package == null)
            {
                return false;
            }
            
            List <DeliveryProposal> deliveryProposals = _dbContext.DeliveryProposals.Include(proposal => proposal.Package)
                .Where(proposal => proposal.Package.PackageID == package.PackageID).ToList();

            foreach (DeliveryProposal deliveryProposal in deliveryProposals)
            {
                _dbContext.DeliveryProposals.Remove(deliveryProposal);
            }
            
            _dbContext.Packages.Remove(package);
            return SaveDbChanges();
        }

        public bool EndDeliveryProcess(int packageId)
        {
            Package package = _dbContext.Packages.SingleOrDefault(package => package.PackageID == packageId);

            if (package == null)
            {
                return false;
            }

            package.Status = Status.Done;
            return SaveDbChanges();
        }

        private User GetUser(string userId)
        {
            return _dbContext.User.Include(u => u.IdentityUser).Include(u => u.DeliveryGuy)
                .SingleOrDefault(u => u.IdentityUser.Id.Equals(userId));
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