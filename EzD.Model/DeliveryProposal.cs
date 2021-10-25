using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzD.Model
{
    // This model represents the bid made by a delivery guy to the package he is intrested in.
    public class DeliveryProposal
    {
        public int ProposalID { get; set; }
        public DeliveryGuy IntrestedDeliveryGuy { get; set; }
        public Package Package { get; set; }
        public float? Price { get; set; }
        public string Comment { get; set; }
    }
}