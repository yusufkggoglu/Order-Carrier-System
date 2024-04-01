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
    public class CarrierConfigurationRepository : RepositoryBase<CarrierConfiguration>, ICarrierConfigurationRepository
    {
        private readonly RepositoryContext _context;
        public CarrierConfigurationRepository(RepositoryContext context) : base(context)
        {
           _context = context;
        }
        public void CreateOneCarrierConfiguration(CarrierConfiguration configuration) => Create(configuration);
        public void DeleteOneCarrierConfiguration(CarrierConfiguration configuration) => Delete(configuration);

        public async Task<List<CarrierConfiguration>> GetAllCarrierConfigurationsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(b => b.CarrierConfigurationId)
                .ToListAsync();
        }

        public async Task<CarrierConfiguration> GetOneCarrierConfigurationByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.CarrierConfigurationId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();


        public async Task<CarrierConfiguration> GetInRange(int desi, bool trackChanges)
        {
            var carrierConf = await FindByCondition(b => b.CarrierMinDesi <= desi && desi <= b.CarrierMaxDesi, trackChanges)
                .OrderBy(b => b.CarrierCost).ToListAsync();

            if (carrierConf.Any())
            {
                foreach(var conf in carrierConf)
                {
                    var carrier = _context.Carriers.FirstOrDefault(c => c.CarrierId == conf.CarrierId && c.CarrierIsActive);
                    if (carrier != null)
                    {
                        return conf;
                    }
                }
            }
            return null;
        }

        public async Task<CarrierConfiguration> GetByCarrierId(int carrierId, bool trackChanges) => 
            await FindByCondition(b => b.CarrierId.Equals(carrierId), trackChanges)
            .FirstOrDefaultAsync();
        public async Task<CarrierConfiguration> GetNearestOne(int desi, bool trackChanges) {
            var carrierConf = await FindByCondition(b => b.CarrierMaxDesi < desi, trackChanges)
                .OrderBy(b => desi - b.CarrierMaxDesi).ThenBy(b=> b.CarrierCost)
                .ToListAsync();
            if (carrierConf.Any())
            {
                foreach (var conf in carrierConf)
                {
                    var carrier = _context.Carriers.FirstOrDefault(c => c.CarrierId == conf.CarrierId && c.CarrierIsActive);
                    if (carrier != null)
                    {
                        return conf;
                    }
                }
            }
            return null;
        }
      
   
   
        public void UpdateOneCarrierConfiguration(CarrierConfiguration configuration) => Update(configuration);
    }
}
