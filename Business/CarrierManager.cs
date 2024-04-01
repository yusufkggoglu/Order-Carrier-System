using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CarrierManager : ICarrierService
    {
        private readonly ICarrierRepository _repository;
        private readonly IMapper _mapper;

        public CarrierManager(ICarrierRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CarrierCreateDto> CreateOneCarrierAsync(CarrierCreateDto carrierDto)
        {
            var entity = _mapper.Map<Carrier>(carrierDto);
           _repository.CreateOneCarrier(entity);
 
            return carrierDto;
        }

        public async Task DeleteOneCarrierAsync(int id, bool trackChanges)
        {
            var entity = await CarrierCheck(id, trackChanges);
           _repository.DeleteOneCarrier(entity);
 
        }

        public async Task<List<Carrier>> GetAllCarriersAsync(bool trackChanges)
        {
            var entities = await _repository.GetAllCarriersAsync(trackChanges);
            return entities;
        }

        public async Task<CarrierDto> GetOneCarrierByIdAsync(int id, bool trackChanges)
        {
            var carrier = await CarrierCheck(id, trackChanges);
            var entity = _mapper.Map<CarrierDto>(carrier);
            return entity;
        }

        public async Task UpdateOneCarrierAsync(int id, CarrierUpdateDto carrierDto, bool trackChanges)
        {
            var check = await CarrierCheck(id, trackChanges);
            var entity =_mapper.Map<Carrier>(carrierDto);
            entity.CarrierId = check.CarrierId;
           _repository.Update(entity);
 
            
        }
        public async Task<List<Carrier>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _repository.GetAllCarriersAsync(trackChanges);
            return books;
        }

        private async Task<Carrier> CarrierCheck(int id, bool trackChanges)
        {
            var entity = await _repository.GetOneCarrierByIdAsync(id, trackChanges);
            if (entity is null)
                throw new ExceptionBase($"{id} carrier not found.");

            return entity;
        }
    }
}
