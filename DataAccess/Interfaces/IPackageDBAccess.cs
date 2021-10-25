using EzD.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.DataAccess.Interfaces
{
    public interface IPackageDBAccess
    {
        // Get all packages that don't match the users ID with the status: Status = Pending.
        public List<Package> GetAllPendingPackages(string userId);
        // Get all of the packages delivered by the user with the status: Status = Done.
        public List<Package> GetAllDonePackagesDelivered(string userId);
        // Add new package to the users database.
        public bool AddPackage(Package package, string userId);
        // Get a package by its ID.
        public Package GetPackage(int packageId);
        // Get all packages sent by a user.
        public List<Package> GetAllPackages(string userId);
        // Change Package details.
        public bool ChangePackageDetails(Package package);
        // Delete a pacakge and all the delivery proposals made for the package.
        public bool DeletePackage(int packageId);
        // End a delivery procces by setting its status to: Status = Done.
        public bool EndDeliveryProcess(int packageId);
    }
}
