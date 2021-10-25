using EzD.Model;
using EzD_App.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.Logic.Interface
{
    public interface IPackageManager
    {
        // Create new package and add it to the database.
        public bool AddPackage(PackageDto package, string userId);
        // Get all packages that don't match the users ID with the status: Status = Pending
        public List<PackageDto> GetAllPendingPackages(string userid);
        // Get all of the packages delivered by the user with the status: Status = Done.
        public List<PackageDto> GetAllDonePackagesDelivered(string userid);
        // Get all packages by user ID
        public List<PackageDto> GetAllPackages(string userId);
        // Change Package details.
        public bool ChangePackageDetails(PackageDto package);
        // Delete a pacakge and all the delivery proposals made for the package.
        public bool DeletePackage(int packageId);
        // End a delivery procces by setting its status to: Status = Done.
        public bool EndDeliveryProcess(int packageId);
        // Get a package by its ID
        public PackageDto GetPackage(int packageId);
    }
}
