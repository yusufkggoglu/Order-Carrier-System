using DataAccess.Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
            
        }
        public void CreateOneOrder(Order order) => Create(order);

        public void DeleteOneOrder(Order order) => Delete(order);   

        public async Task<List<Order>> GetAllOrdersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(b => b.OrderId)
                .ToListAsync();
        }



        public  async Task<Order> GetOneOrderByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.OrderId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();


        public void UpdateOneOrder(Order order)=> Update(order);
    }
}
