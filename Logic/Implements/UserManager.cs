using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EzD.Model;
using EzD_App.DataAccess.Interfaces;
using EzD_App.DTO;
using EzD_App.Logic.Implements;
using EzD_App.Logic.Interfaces;

namespace EzD_App.Logic
{
    public class UserManager :IUserManager
    {
        readonly IUserDBAccess _userDBaccess;

        public UserManager(IUserDBAccess userDBaccess)
        {
            _userDBaccess = userDBaccess;
        }

        public bool AddUserIdentity(UserDto userDTO)
        {
            User user = new()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                IdentityUser = userDTO.IdentityUser
            };

            return _userDBaccess.AddIdentityUser(user);
        }

        public bool UpdateUserName(UserDto userDto, string userId)
        {
            if (userDto == null)
            {
                return false;
            }

            if (!DataValidation.IsNameValid(userDto.FirstName) || !DataValidation.IsNameValid(userDto.LastName))
            {
                return false;
            }

            User user = ConvertDtoToModel.ConvertUserToUserDto(userDto);

            return _userDBaccess.UpdateUserName(user, userId);
        }

        public UserDto GetUserFirstLastName(string userId)
        {
            User user = _userDBaccess.GetUser(userId);
            return ConvertModelToDto.ConvertUserToUserDto(user);
        }

        public bool CreateDeliveryGuy(string userId)
        {
            return _userDBaccess.CreateDeliveryGuy(userId);
        }

        public bool SetDeliveryGuyInactive(string userId)
        {
            return _userDBaccess.SetDeliveryGuyInactive(userId);
        } 

        public DeliveryGuyDto GetDeliveryGuy(string userId)
        {
            DeliveryGuy deliveryGuy = _userDBaccess.GetDeliveryGuy(userId);

            // If the user has never checked the 'Delivery Box' before.
            if (deliveryGuy == null)
            {
                return new DeliveryGuyDto()
                {
                    Active = false
                };
            }

            DeliveryGuyDto deliveryGuyDto = ConvertModelToDto.ConvertDeliveryGuyToDeliveryGuyDto(deliveryGuy);

            return deliveryGuyDto;
        }

        public bool IsDeliveryGuyActive(string userId)
        {
            return _userDBaccess.IsDeliveryGuyActive(userId);
        }

        public string GetEmail(string userId)
        {
            return _userDBaccess.GetEmail(userId);
        }
    }
}