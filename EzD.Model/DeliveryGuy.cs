using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzD.Model
{
    public class DeliveryGuy
    {
        public int DeliveryGuyID { get; set; }
        public float Rank { get; set; }
        public float Credits { get; set; } 
        public bool Active { get; set; }
        public int NumberOfVotes { get; set; }
    }
}
