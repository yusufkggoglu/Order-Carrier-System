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
    public class CarrierConfigurationManager : ICarrierConfigurationService
    {
        private readonly ICarrierConfigurationRepository _confRepository;
        private readonly ICarrierRepository _carrierRepository;
        private readonly IMapper _mapper;
        public CarrierConfigurationManager(ICarrierConfigurationRepository repository, ICarrierRepository carrierRepository,IMapper mapper)
        {
            _confRepository = repository;
            _carrierRepository = carrierRepository;
            _mapper = mapper;
        }
        public async Task<CarrierConfigurationCreateDto> CreateOneCarrierConfigurationAsync(CarrierConfigurationCreateDto carrierConfigurationDto)
        {
            var entity = _mapper.Map<CarrierConfiguration>(carrierConfigurationDto);
            //carrier check and carrierConfigurationId update
            var carrier = await _carrierRepository.GetOneCarrierByIdAsync(entity.CarrierId,false);
            if (carrier == null ) 
            {
                throw new ExceptionBase("Carrier not found.");
            }
            //var isExist = _confRepository.GetByCarrierId(entity.CarrierId, false);
            //if (isExist != null)
            //{
            //    throw new ExceptionBase("The configuration with this carrier id already exists.");

            //}
            _confRepository.CreateOneCarrierConfiguration(entity);

            carrier.CarrierConfigurationId = entity.CarrierConfigurationId;
            _carrierRepository.UpdateOneCarrier(carrier);
            return carrierConfigurationDto;
        }

        public async Task DeleteOneCarrierConfigurationAsync(int id, bool trackChanges)
        {
            var entity =await CarrierConfigurationCheck(id, trackChanges);
            _confRepository.DeleteOneCarrierConfiguration(entity);
        }

        public Task<List<CarrierConfiguration>> GetAllCarrierConfigurationsAsync(bool trackChanges)
        {
            var entities = _confRepository.GetAllCarrierConfigurationsAsync(trackChanges);
            return entities;
        }

        public async Task<CarrierConfigurationDto> GetOneCarrierConfigurationByIdAsync(int id, bool trackChanges)
        {
            var entity = await CarrierConfigurationCheck(id,trackChanges);
            var dto = _mapper.Map<CarrierConfigurationDto>(entity);
            return dto;
        }

        public async Task UpdateOneCarrierConfigurationAsync(int id, CarrierConfigurationUpdateDto carrierConfigurationDto, bool trackChanges)
        {
            var check = await CarrierConfigurationCheck(id, trackChanges);
            var entity = _mapper.Map<CarrierConfiguration>(carrierConfigurationDto);
            entity.CarrierConfigurationId = check.CarrierConfigurationId;
            //carrier check and carrierConfigurationId update
            var carrier = await _carrierRepository.GetOneCarrierByIdAsync(entity.CarrierId, false);
            if (carrier == null)
            {
                throw new Exception("Carrier not found.");
            }
            //var isExist = _confRepository.GetByCarrierId(entity.CarrierId, false);
            //if (isExist != null)
            //{
            //    throw new ExceptionBase("The configuration with this carrier id already exists.");

            //}
            carrier.CarrierConfigurationId = entity.CarrierConfigurationId;
            _carrierRepository.UpdateOneCarrier(carrier);
            _confRepository.UpdateOneCarrierConfiguration(entity);
        }

        private async Task<CarrierConfiguration> CarrierConfigurationCheck(int id, bool trackChanges)
        {
            var entity = await _confRepository.GetOneCarrierConfigurationByIdAsync(id, trackChanges);
            if (entity is null)
                throw new ExceptionBase($"{id} carrier configuration not found.");

            return entity;
        }
    }
}
