using DataAccess.Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.EFCore
{
    public class CarrierRepository : RepositoryBase<Carrier> , ICarrierRepository
    {
        public CarrierRepository(RepositoryContext context) : base(context)
        {
           
        }
        public void CreateOneCarrier(Carrier carrier) => Create(carrier);

        public void DeleteOneCarrier(Carrier carrier) => Delete(carrier);

        public async Task<Carrier> GetOneCarrierByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.CarrierId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateOneCarrier(Carrier carrier) => Update(carrier);

        public async Task<List<Carrier>> GetAllCarriersAsync(bool trackChanges)
        {
            return await FindByCondition(b => b.CarrierIsActive == true,trackChanges)
                .OrderBy(b => b.CarrierId)
                .ToListAsync();
        }

    }
}
