using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._2
{
    public class DeliveryResult
    {
        public bool Success { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public string ErrorMessage { get; set; }
    }
    public enum DeliveryProviderType
    {
        Internal,
        ExternalA,
        ExternalB,
        ExternalC
    }
}
