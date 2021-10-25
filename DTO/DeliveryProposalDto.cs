using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.DTO
{
    public class DeliveryProposalDto
    {
        public int ProposalID { get; set; }
        public DeliveryGuyDto IntrestedDeliveryGuy { get; set; }
        public PackageDto Package { get; set; }
        public float? Price { get; set; }
        public string Comment { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
