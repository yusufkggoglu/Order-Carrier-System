using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IOrderService
    {
        Task<OrderDto> GetOneOrderByIdAsync(int id, bool trackChanges);
        Task<OrderCreateDto> CreateOneOrderAsync(OrderCreateDto orderDto);
        Task UpdateOneOrderAsync(int id, OrderUpdateDto orderDto, bool trackChanges);
        Task DeleteOneOrderAsync(int id, bool trackChanges);
        Task<List<Order>> GetAllOrdersAsync(bool trackChanges);
    }
}
