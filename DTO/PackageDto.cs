using EzD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzD_App.DTO
{
    public enum Status
    {
        Pending,
        InProgress,
        Done,
        Error,
        Cancel
    }
    public class PackageDto
    {
        public int PackageID { get; set; }
        public string SenderPhone { get; set; }
        public string ContactPhone { get; set; }
        public float Weight { get; set; }
        public string Description { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DeadLineDate { get; set; }
        public AddressDto FromAddress { get; set; }
        public AddressDto ToAddress { get; set; }
        public float Price { get; set; }
        public bool SenderIsReceiver { get; set; }
        public DeliveryGuyDto IntrestedDeliveryGuy { get; set; }//delete?
        public Status Status { get; set; }
        public UserDto Owner { get; set; }
    }
}
