using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUpdateRepository<T> where T : class, new()
    {
        Task<T> UpdateAsync(T review);
    }    
}