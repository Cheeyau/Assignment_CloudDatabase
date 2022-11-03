using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Review
    {
        public string? UserId { get; set; }
        public string ProductId { get; set; }
        public string ReviewText { get; set; }
    }
}
