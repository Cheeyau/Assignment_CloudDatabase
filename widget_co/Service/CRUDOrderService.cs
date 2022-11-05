using Domain;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CRUDOrderService<T> : ICRUDService<T> where T : class, new()
    {
        private readonly IDeleteRepository<Order> _deleteRepository;
        private readonly IReadRepository<Order> _readRepository;
        private readonly ICreateRepository<Order> _createRepository;
        private readonly IUpdateRepository<Order> _updateRepository;
        
        public CRUDOrderService(
            IDeleteRepository<Order> deleteRepository,
            IReadRepository<Order> readRepository,
            ICreateRepository<Order> createRepository,
            IUpdateRepository<Order> updateRepository
        ) {
            _deleteRepository = deleteRepository;
            _readRepository = readRepository;
            _createRepository = createRepository;
            _updateRepository = updateRepository;
        }
        public async Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> DeleteAsync(T id)
        {
            
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(T id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
