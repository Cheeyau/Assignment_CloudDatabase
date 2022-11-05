using Domain;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAllAsync();
        Task<Review> GetByIdAsync(ReviewDTO reviewDTO);
        Task<Review> CreateAsync(ReviewDTO reviewDTO);
        Task DeleteAsync(ReviewDTO reviewDTO);
        Task<Review> UpdateAsync(ReviewDTO reviewDTO, string id);
    }
}
