using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EzD.Model;
using EzD_App.DataAccess.Interfaces;
using EzD_App.DTO;
using EzD_App.Logic.Implements;
using EzD_App.Logic.Interface;
using Microsoft.AspNetCore.Identity;

namespace EzD_App.Logic
{
    public class PackageManager : IPackageManager
    {
        readonly IPackageDBAccess _packageDBaccess;
        public PackageManager(IPackageDBAccess packageDBaccess)
        {
            _packageDBaccess = packageDBaccess;
        }

        public bool AddPackage(PackageDto package, string userId)
        {
            if (package == null || !DataValidation.IsPackageValid(package))
            {
                return false;
            }

            Package newPackage = ConvertDtoToModel.ConvertPackageDtoToPackage(package);
            newPackage.Status = EzD.Model.Status.Pending;

            return _packageDBaccess.AddPackage(newPackage, userId);
        }
        
        public List<PackageDto> GetAllPendingPackages(string userid)
        {
            List<Package> packages = _packageDBaccess.GetAllPendingPackages(userid);
            List<PackageDto> packagesDto = new();

            foreach(Package package in packages)
            {
                packagesDto.Add(ConvertModelToDto.ConvertPackageToPackageDto(package));
            }
            
            return packagesDto;
        }   

        public List<PackageDto> GetAllDonePackagesDelivered(string userid)
        {
            List<Package> packages = _packageDBaccess.GetAllDonePackagesDelivered(userid);
            List<PackageDto> packagesDto = new();

            foreach(Package package in packages)
            {
                packagesDto.Add(ConvertModelToDto.ConvertPackageToPackageDto(package));
            }
            
            return packagesDto;
        }   
        
        public List<PackageDto> GetAllPackages(string userId)
        {
            List<Package> packages = _packageDBaccess.GetAllPackages(userId);
            List<PackageDto> packagesDto = new List<PackageDto>();

            foreach (Package package in packages)
            {
                packagesDto.Add(ConvertModelToDto.ConvertPackageToPackageDto(package));
            }

            return packagesDto;
        }

        public bool ChangePackageDetails(PackageDto packageDto)
        {
            Package editedPackage = ConvertDtoToModel.ConvertPackageDtoToPackage(packageDto);
            return _packageDBaccess.ChangePackageDetails(editedPackage);
        }

        public bool DeletePackage(int packageId)
        {
            return _packageDBaccess.DeletePackage(packageId);
        }

        public bool EndDeliveryProcess(int packageId)
        {
            return _packageDBaccess.EndDeliveryProcess(packageId);
        }

        public PackageDto GetPackage(int packageId)
        {
            Package package = _packageDBaccess.GetPackage(packageId);
            return ConvertModelToDto.ConvertPackageToPackageDto(package);
        }
    }
}
