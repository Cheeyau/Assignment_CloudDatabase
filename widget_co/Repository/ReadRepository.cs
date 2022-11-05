using DAL;
using Domain;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, new()
    {
        private readonly DataBaseContext _dataBaseContext;
        public ReadRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public IQueryable<T> GetAllAsync()
        {
            var entities = _dataBaseContext.Set<T>().AsQueryable();
            if (entities == null)
                throw new NullReferenceException("Could not retrieve the data.");
            return entities;
        }
    }
}