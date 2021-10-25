using EzD_App.DTO;
using EzD_App.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.Controllers
{
    [Route("api/DeliveryProposal")]
    [ApiController]
    [Authorize]
    public class DeliveryProposalController : ControllerBase
    {
        readonly IDeliveryProposalManager _deliveryProposalManager;
        readonly UserManager<IdentityUser> _userManager;

        public DeliveryProposalController(IDeliveryProposalManager deliveryProposalManager, UserManager<IdentityUser> userManager)
        {
            _deliveryProposalManager = deliveryProposalManager;
            _userManager = userManager;
        }

       
        [HttpPost]
        [Route("/api/DeliveryProposal/AddDeliveryProposal")]
        public string AddDeliveryProposal(DeliveryProposalDto deliveryProposalDto)
        {
            string userId = _userManager.GetUserId(User);
            _deliveryProposalManager.AddDeliveryProposal(userId, deliveryProposalDto);

            return JsonConvert.SerializeObject(userId);                
        }

        [HttpPost]
        [Route("/api/DeliveryProposal/GetDeliveryProposalsByUser")]
        public string GetDeliveryProposalsByUser()
        {
            string userId = _userManager.GetUserId(User);
            return JsonConvert.SerializeObject(_deliveryProposalManager.GetDeliveryProposalsByUser(userId));
        }

        [HttpPost]
        [Route("/api/DeliveryProposal/GetDeliveryGuysByPackageId")]
        public string GetDeliveryGuysByPackageId([FromBody]int packageId)
        {
            return JsonConvert.SerializeObject(_deliveryProposalManager.GetDeliveryProposalsForPackage(packageId));
        }

        [HttpDelete]
        [Route("/api/DeliveryProposal/DeleteDeliveryProposal")]
        public string DeleteDeliveryProposal([FromBody]int deliveryProposalId)
        {
            return JsonConvert.SerializeObject(_deliveryProposalManager.DeleteDeliveryProposal(deliveryProposalId));
        }
    }
}
