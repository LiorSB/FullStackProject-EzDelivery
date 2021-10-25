using EzD.Model;
using EzD_App.DTO;
using EzD_App.Logic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EzD_App.Controllers
{
    [Route("api/Package")]
    [ApiController]
    [Authorize]
    public class PackageController : ControllerBase
    {
        readonly IPackageManager _packageManager;
        readonly UserManager<IdentityUser> _userManager;

        public PackageController(IPackageManager packageManager, UserManager<IdentityUser> userManager)
        {
            _packageManager = packageManager;
            _userManager = userManager;
        }
        
        [HttpPost("{id}")]
        [Route("/api/Package/GetAllPendingPackages")]
        public string GetAllPendingPackages()
        { 
            string userid = _userManager.GetUserId(User);
            List<PackageDto> packagesDto = _packageManager.GetAllPendingPackages(userid);

            return JsonConvert.SerializeObject(packagesDto);
        } 
        
        [HttpPost("{id}")]
        [Route("/api/Package/GetAllDonePackagesDelivered")]
        public string GetAllDonePackagesDelivered()
        { 
            string userid = _userManager.GetUserId(User);
            List<PackageDto> packagesDto = _packageManager.GetAllDonePackagesDelivered(userid);

            return JsonConvert.SerializeObject(packagesDto);
        }

        [HttpPost]
        [Route("/api/Package/AddPackage")]
        public string AddPackage(PackageDto package)
        {
            string userId = _userManager.GetUserId(User);
            return JsonConvert.SerializeObject(_packageManager.AddPackage(package, userId));
        }

        [HttpGet]
        [Route("/api/Package/GetAllPackages")]
        public string GetAllPackages()
        {
            string userId = _userManager.GetUserId(User);
            List<PackageDto> packagesDto = _packageManager.GetAllPackages(userId);
        
            return JsonConvert.SerializeObject(packagesDto);
        }

        [HttpPut]
        [Route("/api/Package/ChangePackageDetails")]
        public string ChangePackageDetails([FromBody] PackageDto package)
        {
            return JsonConvert.SerializeObject(_packageManager.ChangePackageDetails(package));
        }

        [HttpDelete]
        [Route("/api/Package/DeletePackage/{PackageId}")]
        public string DeletePackage(int PackageId)
        {
            return JsonConvert.SerializeObject(_packageManager.DeletePackage(PackageId));
        }

        [HttpPost]
        [Route("/api/Package/EndDeliveryProcess")]
        public string EndDeliveryProcess([FromBody]int packageId)
        {
            return JsonConvert.SerializeObject(_packageManager.EndDeliveryProcess(packageId));
        }

        [HttpPost]
        [Route("/api/Package/GetPackage")]
        public string GetPackage([FromBody]int packageId)
        {
            return JsonConvert.SerializeObject(_packageManager.GetPackage(packageId));
        }
    }
}