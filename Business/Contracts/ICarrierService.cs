using Entities.Dtos;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface ICarrierService
    {
        Task<CarrierDto> GetOneCarrierByIdAsync(int id, bool trackChanges);
        Task<CarrierCreateDto> CreateOneCarrierAsync(CarrierCreateDto carrierDto);
        Task UpdateOneCarrierAsync(int id, CarrierUpdateDto carrierDto, bool trackChanges);
        Task DeleteOneCarrierAsync(int id, bool trackChanges);
        Task<List<Carrier>> GetAllCarriersAsync(bool trackChanges);
    }
}
