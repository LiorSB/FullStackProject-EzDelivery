using EzD.Model;
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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EzD_App.Controllers
{
    [Route("api/ApprovedDelivery")]
    [ApiController]
    [Authorize]
    public class ApprovedDeliveryController : ControllerBase
    {
        readonly IApprovedDeliveryManager _ApprovedDeliveryManager;
        readonly UserManager<IdentityUser> _userManager;

        public ApprovedDeliveryController(IApprovedDeliveryManager ApprovedDeliveryManager, UserManager<IdentityUser> userManager)
        {
            _ApprovedDeliveryManager = ApprovedDeliveryManager;
            _userManager = userManager;
        }

        // GET: api/<ApprovedDeliveryController>
        [HttpGet]
        [Route("/api/ApprovedDelivery/GetApprovedDeliveries")]
        public string GetApprovedDeliveries()
        {
            string userId = _userManager.GetUserId(User);
            return JsonConvert.SerializeObject(_ApprovedDeliveryManager.GetApprovedDeliveries(userId));
        }

        [HttpPost]
        [Route("/api/ApprovedDelivery/ApproveDeliveryProposal")]
        public string ApproveDeliveryProposal(DeliveryProposalDto deliveryProposalDto)
        {
            return JsonConvert.SerializeObject(_ApprovedDeliveryManager.ApproveDeliveryProposal(deliveryProposalDto));
        }

        [HttpGet]
        [Route("/api/ApprovedDelivery/GetAllVotes")]
        public string GetAllVotes()
        {
            string userId = _userManager.GetUserId(User);
            return JsonConvert.SerializeObject(_ApprovedDeliveryManager.GetAllVotes(userId));
        }

        [HttpPut]
        [Route("/api/ApprovedDelivery/AddDeliveryRank/{packageId}")]
        public string AddDeliveryRank([FromBody]int rank,int packageId)
        {
            return JsonConvert.SerializeObject(_ApprovedDeliveryManager.AddDeliveryRank(rank, packageId));
        }
    }
}
