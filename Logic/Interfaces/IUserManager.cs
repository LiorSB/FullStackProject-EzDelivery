using EzD_App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.Logic.Interfaces
{
    public interface IUserManager
    {
        // Add an IdentityUser to the user.
        public bool AddUserIdentity(UserDto userDTO);
        // Updates a users first and last name.
        public bool UpdateUserName(UserDto userDTO, string userId);
        // Get a users first and last name by their ID.
        public UserDto GetUserFirstLastName(string userId);
        // Re-activate a delivery guy or create a new one for the user.
        public bool CreateDeliveryGuy(string userId);
        // Set the the delivery guys status to false.
        public bool SetDeliveryGuyInactive(string userId);
        // Get a DeliveryGuy by the users ID.
        public DeliveryGuyDto GetDeliveryGuy(string userId);
        // Check if the user is an active delivery guy.
        public bool IsDeliveryGuyActive(string userId);
        // Get the users Email.
        public string GetEmail(string userId);

    }
}
