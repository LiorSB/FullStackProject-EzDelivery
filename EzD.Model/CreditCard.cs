using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzD.Model
{
    public class CreditCard
    {
        public string CCNum { get; set; }
        public int CVV { get; set; }
        public DateTime Validity { get; set; }
    }
}
