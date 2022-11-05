using Domain;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CRUDProductService<T> : ICRUDService<T> where T : class, new()
    {
        private readonly IDeleteRepository<Product> _deleteRepository;
        private readonly IReadRepository<Product> _readRepository;
        private readonly ICreateRepository<Product> _createRepository;
        private readonly IUpdateRepository<Product> _updateRepository;

        public CRUDProductService(
            IDeleteRepository<Product> deleteRepository, 
            IReadRepository<Product> readRepository, 
            ICreateRepository<Product> createRepository, 
            IUpdateRepository<Product> updateRepository)
        {
            _deleteRepository = deleteRepository;
            _readRepository = readRepository;
            _createRepository = createRepository;
            _updateRepository = updateRepository;
        }

        public Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(T id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(T id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
