using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IReadRepository<T> where T : class
    {
        IQueryable<T> GetAllAsync();
    }
}
