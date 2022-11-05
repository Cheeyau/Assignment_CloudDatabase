using Domain.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order> GetByIDAsync(OrderDTO orderDTO);
        Task<Order> CreateAsync(OrderDTO orderDTO);
        Task DeleteAsync(OrderDTO orderDTO);
        Task<Order> UpdateAsync(OrderDTO orderDTO, string id);
        Task<Order> UpdateOrderShippingAsync(DateTime orderDTO, string id);

    }
}
