using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface ICarrierRepository : IRepositoryBase<Carrier>
    {
        Task<List<Carrier>> GetAllCarriersAsync(bool trackChanges);
        Task<Carrier> GetOneCarrierByIdAsync(int id, bool trackChanges);
        void CreateOneCarrier(Carrier carrier);
        void UpdateOneCarrier(Carrier carrier);
        void DeleteOneCarrier(Carrier carrier);
    }
}
