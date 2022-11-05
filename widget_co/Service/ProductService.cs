using AutoMapper;
using Domain;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService 
    {
        private readonly IDeleteRepository<Product> _deleteRepository;
        private readonly IReadRepository<Product> _readRepository;
        private readonly ICreateRepository<Product> _createRepository;
        private readonly IUpdateRepository<Product> _updateRepository;
        private readonly IMapper _mapper;
        public ProductService(
            IDeleteRepository<Product> deleteRepository, 
            IReadRepository<Product> readRepository, 
            ICreateRepository<Product> createRepository, 
            IUpdateRepository<Product> updateRepository
        ) {
            _deleteRepository = deleteRepository;
            _readRepository = readRepository;
            _createRepository = createRepository;
            _updateRepository = updateRepository;
        }
        public ProductService(IMapper mapper) => _mapper = mapper;
        public async Task<Product> CreateAsync(ProductDTO productDTO)
        {
            productDTO.ProductId = Guid.NewGuid().ToString();
            Product product = _mapper.Map<ProductDTO, Product>(productDTO);

            return await _createRepository.CreateAsync(product);
        }

        public async Task DeleteAsync(ProductDTO productDTO)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productDTO);
            if (!String.IsNullOrEmpty(product.ProductId)) 
                await _deleteRepository.DeleteAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {

            return await _readRepository.GetAllAsync().ToListAsync();
        }

        public async Task<Product> GetByIDAsync(ProductDTO productDTO)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productDTO);
            if (String.IsNullOrEmpty(product.ProductId))
                return product = new();

            return ((product = await _readRepository.GetAllAsync().FirstOrDefaultAsync(p => p.ProductId == product.ProductId)) == null) ? product = new() : product;
        }

        public async Task<Product> UpdateAsync(ProductDTO productDTO, string id)
        {
            if (String.IsNullOrEmpty(id))
                return new Product();

            Product product = _mapper.Map<ProductDTO, Product>(productDTO);
            ProductDTO newProductDTO = new();
            newProductDTO.ProductId = id;
            Product productOld = await GetByIDAsync(newProductDTO);
            productOld = product;
            productOld.ProductId = id;
            return await _updateRepository.UpdateAsync(productOld);
        }
    }
}
