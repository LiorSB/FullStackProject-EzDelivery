using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.DTO
{
    public class DeliveryGuyDto
    {
        public int DeliveryGuyID { get; set; }
        public float Rank { get; set; }
        public float Credits { get; set; }
        public bool Active { get; set; }
        public int NumberOfVotes { get; set; }
    }
}
