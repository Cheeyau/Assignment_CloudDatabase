using Domain.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllOrderAsync();
        Task<User> GetByIDAsync(UserDTO UserDTO);
        Task<User> CreateAsync(UserDTO UserDTO);
        Task DeleteAsync(UserDTO UserDTO);
        Task<User> UpdateAsync(UserDTO UserDTO, string id);
    }
}
