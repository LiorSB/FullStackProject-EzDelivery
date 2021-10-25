using EzD.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.DTO
{
    public class UserDto
    {
        public int UserID { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Credits { get; set; }
        public List<PackageDto> MyPackages { get; set; }
        public DeliveryGuyDto DeliveryGuy { get; set; }
    }
}
