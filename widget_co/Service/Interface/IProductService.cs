using Domain.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product> GetByIDAsync(ProductDTO productDTO);
        Task<Product> CreateAsync(ProductDTO productDTO);
        Task DeleteAsync(ProductDTO productDTO);
        Task<Product> UpdateAsync(ProductDTO productDTO, string id);
    }
}
