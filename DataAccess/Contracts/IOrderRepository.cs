using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface  IOrderRepository : IRepositoryBase<Order>
    {
        Task<List<Order>> GetAllOrdersAsync(bool trackChanges);
        Task<Order> GetOneOrderByIdAsync(int id, bool trackChanges);
        void CreateOneOrder(Order order);
        void UpdateOneOrder(Order order);
        void DeleteOneOrder(Order order);
    }
}
