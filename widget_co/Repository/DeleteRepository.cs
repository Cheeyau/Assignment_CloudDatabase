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
    public class DeleteRepository<T> : IDeleteRepository<T> where T : class
    {
        private readonly DataBaseContext _dataBaseContext;
        public DeleteRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task DeleteAsync(T id)
        {
            _dataBaseContext.Remove(id);
            await _dataBaseContext.SaveChangesAsync();
        }
    }
}
