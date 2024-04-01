using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface ICarrierConfigurationRepository : IRepositoryBase<CarrierConfiguration>
    {
        Task<List<CarrierConfiguration>> GetAllCarrierConfigurationsAsync(bool trackChanges);
        Task<CarrierConfiguration> GetOneCarrierConfigurationByIdAsync(int id, bool trackChanges);
        void CreateOneCarrierConfiguration(CarrierConfiguration configuration);
        void UpdateOneCarrierConfiguration(CarrierConfiguration configuration);
        void DeleteOneCarrierConfiguration(CarrierConfiguration configuration);
        public Task<CarrierConfiguration> GetInRange(int desi, bool trackChanges);
        public Task<CarrierConfiguration> GetNearestOne(int desi, bool trackChanges);
        public Task<CarrierConfiguration> GetByCarrierId(int carrierId, bool trackChanges);
    }
}
