using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface ICarrierConfigurationService
    {
        Task<CarrierConfigurationDto> GetOneCarrierConfigurationByIdAsync(int id, bool trackChanges);
        Task<CarrierConfigurationCreateDto> CreateOneCarrierConfigurationAsync(CarrierConfigurationCreateDto CarrierConfigurationDto);
        Task UpdateOneCarrierConfigurationAsync(int id, CarrierConfigurationUpdateDto CarrierConfigurationDto, bool trackChanges);
        Task DeleteOneCarrierConfigurationAsync(int id, bool trackChanges);
        Task<List<CarrierConfiguration>> GetAllCarrierConfigurationsAsync(bool trackChanges);
    }
}
