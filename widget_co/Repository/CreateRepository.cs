using DAL;
using Domain;
using Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CreateRepository<T> : ICreateRepository<T> where T : class, new()
    {
        private readonly DataBaseContext _dataBaseContext;
        public CreateRepository(DataBaseContext dataBaseContext) 
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            _dataBaseContext.Add(entity);
            await _dataBaseContext.SaveChangesAsync();
            return entity;
        }
    }
}
