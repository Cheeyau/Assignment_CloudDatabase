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
    public class CRUDUserService<T> : ICRUDService<T> where T : class, new()
    {
        private readonly IDeleteRepository<User> _deleteRepository;
        private readonly IReadRepository<User> _readRepository;
        private readonly ICreateRepository<User> _createRepository;
        private readonly IUpdateRepository<User> _updateRepository;

        public CRUDUserService(
            IDeleteRepository<User> deleteRepository, 
            IReadRepository<User> readRepository, 
            ICreateRepository<User> createRepository, 
            IUpdateRepository<User> updateRepository
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
