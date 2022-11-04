using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public string OrderId { get; set; }
        public string productId { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrderShippedDate { get; set; }
    }
}