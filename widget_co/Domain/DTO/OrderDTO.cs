using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    internal class OrderDTO
    {
        public string? OrderId { get; set; }
        public Dictionary<ProductDTO, int>? products { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? OrderShippedDate { get; set; }
    }
}
