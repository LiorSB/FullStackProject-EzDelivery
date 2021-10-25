using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzD.Model
{
    public enum Status
    {
        Pending,
        InProgress,
        Done,
        Error,
        Cancel
    }
    public class Package
    {
        public int PackageID { get; set; }
        public string SenderPhone { get; set; }
        public string ContactPhone { get; set; }
        public float Weight { get; set; }
        public string Description { get; set; }
        public DateTime PickUpDate{ get; set; }
        public DateTime DeadLineDate { get; set; }
        public Address FromAddress { get; set; } 
        public Address ToAddress { get; set; } 
        public float Price{ get; set; }
        public bool SenderIsReceiver{ get; set; }        
        public Status Status{ get; set; }
        public User Owner { get; set; }
    }
}
