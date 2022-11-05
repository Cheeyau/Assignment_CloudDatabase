using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ReviewDTO
    {
        public string ReviewId { get; set; }
        public string? UserId { get; set; }
        public string ProductId { get; set; }
        public string ReviewText { get; set; }
    }
}
