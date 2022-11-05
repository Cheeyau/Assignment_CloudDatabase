using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IDeleteRepository<T> where T : class
    {
        Task DeleteAsync(T id);
    }
}