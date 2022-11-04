using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ProductDTO
    {
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public List<string>? ProductPhotos { get; set; }
    }
}