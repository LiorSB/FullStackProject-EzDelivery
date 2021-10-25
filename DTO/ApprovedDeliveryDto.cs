using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.DTO
{
    public class ApprovedDeliveryDto
    {
        public int DeliveryID { get; set; }
        public DeliveryGuyDto ChosenDeliveryGuy { get; set; }
        public PackageDto Package { get; set; }
        public float Price { get; set; }
        public int? RankScore { get; set; }
    }
}
