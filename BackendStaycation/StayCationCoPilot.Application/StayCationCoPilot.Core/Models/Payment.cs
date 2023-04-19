using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCationCoPilot.Core.Models
{
    public class Payment
    {
        public string BookingId { get; set; }
        public string BookingPaymentType { get; set; }
        public string BookingPaymentStatus { get; set; }
    }
}
