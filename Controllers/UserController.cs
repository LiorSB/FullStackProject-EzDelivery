using EzD_App.DTO;
using EzD_App.Logic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EzD_App.Controllers
{
    public class UserController : ControllerBase
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly IUserManager _userMng;

        public UserController(IUserManager userMng, UserManager<IdentityUser> userManager)
        {
            _userMng = userMng;
            _userManager = userManager;
        }

        // This controller is used to get a FirstName & LastName from the user.
        // We will update the data in the DB accordingly.
        [HttpPost]
        [Route("/api/User/UpdateUserName")]
        public string UpdateUserName([FromBody] UserDto userDto)
        {
            string userId = _userManager.GetUserId(User);
            return JsonConvert.SerializeObject(_userMng.UpdateUserName(userDto, userId));
        }

        // This controller will get the User information and will send it to the website.
        // Therefore, we will be able to put this data as the page loads.
        // POST api/<UserController>/LoadPersonalInfo
        [HttpPost]
        [Route("/api/User/GetUserFirstLastName")]
        public string GetUserFirstLastName()
        {
            string userId = _userManager.GetUserId(User);
            UserDto userDto = _userMng.GetUserFirstLastName(userId);

            return JsonConvert.SerializeObject(userDto);
        }

        [HttpPut]
        [Route("/api/User/CreateDeliveryGuy")]
        public string CreateDeliveryGuy()
        {
            string userId = _userManager.GetUserId(User);
            return JsonConvert.SerializeObject(_userMng.CreateDeliveryGuy(userId));
        }

        [HttpDelete]
        [Route("/api/User/SetDeliveryGuyInactive")]
        public string SetDeliveryGuyInactive()
        {
            string userId = _userManager.GetUserId(User);
            return JsonConvert.SerializeObject(_userMng.SetDeliveryGuyInactive(userId));
        }

        // This controller will get the Delivery Guy and will send it to the website.
        // Therefore, we will be able to put this data as the page loads.
        // POST api/<UserController>/LoadPersonalInfo
        [HttpGet]
        [Route("/api/User/GetDeliveryGuy")]
        public string GetDeliveryGuy()
        {
            string userId = _userManager.GetUserId(User);
            DeliveryGuyDto deliveryGuyrDto = _userMng.GetDeliveryGuy(userId);

            return JsonConvert.SerializeObject(deliveryGuyrDto);
        }

        // This controller will get the UserID and will send it to the website.
        // Therefore, we will change the state of the navbar according to the DeliveryGuy/Or not.
        // POST api/<UserController>/LoadPersonalInfo
        [HttpPost]
        [Route("/api/User/NavbarState")]
        public string NavbarState()
        {
            string userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return JsonConvert.SerializeObject(false);
            }

            bool navbarState= _userMng.IsDeliveryGuyActive(userId);

            return JsonConvert.SerializeObject(navbarState);
        }

        // This controller will get the UserID and will send his email to the website.
        // Therefore, we will add his email to the navbar to know who is logged in.
        // POST api/<UserController>/LoadPersonalInfo
        [HttpPost]
        [Route("/api/User/GetEmailForNavbar")]
        public string GetEmailForNavbar()
        {
            string userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return JsonConvert.SerializeObject(false);
            }

            string userEmail = _userMng.GetEmail(userId);

            return JsonConvert.SerializeObject(userEmail);
        }
    }
}