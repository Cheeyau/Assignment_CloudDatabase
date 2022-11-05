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
    public class CRUDReviewService<T> : ICRUDService<T> where T : class, new()
    {
        private readonly IDeleteRepository<Review> _deleteRepository;
        private readonly IReadRepository<Review> _readRepository;
        private readonly ICreateRepository<Review> _createRepository;
        private readonly IUpdateRepository<Review> updateRepository;

        public CRUDReviewService(
            IDeleteRepository<Review> deleteRepository, 
            IReadRepository<Review> readRepository, 
            ICreateRepository<Review> createRepository, 
            IUpdateRepository<Review> updateRepository
        ) {
            _deleteRepository = deleteRepository;
            _readRepository = readRepository;
            _createRepository = createRepository;
            this.updateRepository = updateRepository;
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
