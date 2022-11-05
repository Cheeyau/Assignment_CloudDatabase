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
    public class UpdateRepository<T> : IUpdateRepository<T> where T : class, new()
    {
        private readonly DataBaseContext _dataBaseContext;
        public UpdateRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dataBaseContext.Update(entity);
            await _dataBaseContext.SaveChangesAsync();
            return entity;
        }
    }
}
