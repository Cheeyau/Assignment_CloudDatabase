using AutoMapper;
using Domain;
using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IDeleteRepository<Order> _deleteRepository;
        private readonly IReadRepository<Order> _readRepository;
        private readonly ICreateRepository<Order> _createRepository;
        private readonly IUpdateRepository<Order> _updateRepository;
        private readonly IMapper _mapper;
        
        public OrderService(
            IDeleteRepository<Order> deleteRepository,
            IReadRepository<Order> readRepository,
            ICreateRepository<Order> createRepository,
            IUpdateRepository<Order> updateRepository
        ) {
            _deleteRepository = deleteRepository;
            _readRepository = readRepository;
            _createRepository = createRepository;
            _updateRepository = updateRepository;
        }
        public OrderService(IMapper mapper) => _mapper = mapper;

        public async Task<Order> CreateAsync(OrderDTO orderDTO)
        {
            orderDTO.OrderId = Guid.NewGuid().ToString();
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
            
            return await _createRepository.CreateAsync(order);
        }

        public async Task DeleteAsync(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
            if (!String.IsNullOrEmpty(order.OrderId))
                await _deleteRepository.DeleteAsync(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _readRepository.GetAllAsync().ToListAsync();
        }

        public async Task<Order> GetByIDAsync(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
            if (String.IsNullOrEmpty(order.OrderId))
                return order = new();

            return ((order = await _readRepository.GetAllAsync().FirstOrDefaultAsync(p => p.OrderId == order.OrderId)) == null) ? order = new() : order;
        }

        public async Task<Order> UpdateAsync(OrderDTO orderDTO, string id)
        {
            if (String.IsNullOrEmpty(id))
                return new Order();

            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
            OrderDTO newOrderDTO = new();
            newOrderDTO.OrderId = id;
            Order orderOld = await GetByIDAsync(newOrderDTO);
            orderOld = order;
            orderOld.OrderId = id;
            return await _updateRepository.UpdateAsync(orderOld);
        }

        public async Task<Order> UpdateOrderShippingAsync(DateTime datetime, string id)
        {
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(datetime.ToString()))
                return new Order();

            OrderDTO newOrderDTO = new();
            newOrderDTO.OrderId = id;
            Order orderOld = await GetByIDAsync(newOrderDTO);
            orderOld.OrderShippedDate = datetime;
            return await _updateRepository.UpdateAsync(orderOld);
        }
    }
}
