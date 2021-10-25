using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzD.Model
{
    // This model represents the relation between a delivery guy
    // that was chosen by the sender and the package sent.
    public class ApprovedDelivery
    {
        public int DeliveryID { get; set; }
        public DeliveryGuy ChosenDeliveryGuy { get; set; }
        public Package Package { get; set; }
        public float Price { get; set; }
        public int? RankScore { get; set; } 
    }
}