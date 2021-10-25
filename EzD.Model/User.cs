using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzD.Model
{
    public class User
    {
        public string FirstName{ get; set; }
        public string LastName { get; set; }  
        public string Credits { get; set; }
        public List<Package> MyPackages { get; set; }
        public int UserID { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public DeliveryGuy DeliveryGuy { get; set; }
    }
}
