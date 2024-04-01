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
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICarrierConfigurationRepository _configurationRepository;
        private readonly ICarrierRepository _carrierRepository;
        private readonly IMapper _mapper;

        public OrderManager(IOrderRepository repository, IMapper mapper,ICarrierConfigurationRepository configurationRepository, ICarrierRepository carrierRepository)
        {
            _orderRepository = repository;
            _mapper = mapper;
            _configurationRepository = configurationRepository;
            _carrierRepository = carrierRepository;
        }
        public async Task<OrderCreateDto> CreateOneOrderAsync(OrderCreateDto orderDto)
        {
            var entity = _mapper.Map<Order>(orderDto);
            entity.OrderDate = DateTime.Now;
            var inRange = await _configurationRepository.GetInRange(orderDto.OrderDesi, false);
            if(inRange != null)
            {
                entity.OrderCarrierCost = inRange.CarrierCost;
                entity.CarrierId = inRange.CarrierId;
                _orderRepository.CreateOneOrder(entity);
                return orderDto;
            } 
            var theNearest = await _configurationRepository.GetNearestOne(orderDto.OrderDesi, false);
            if(theNearest == null)
            {
                throw new Exception("No cargo company could be found within the suitable desi range for your order.");
            }
            var carrier = await _carrierRepository.GetOneCarrierByIdAsync(theNearest.CarrierId, false);
            var cost = theNearest.CarrierCost + ((orderDto.OrderDesi - theNearest.CarrierMaxDesi) * carrier.CarrierPlusDesiCost);

            entity.OrderCarrierCost = cost;
            entity.CarrierId = carrier.CarrierId;
            _orderRepository.CreateOneOrder(entity);
            return orderDto;
        }

        public async Task DeleteOneOrderAsync(int id, bool trackChanges)
        {
            var entity = await OrderCheck(id, trackChanges);
            _orderRepository.DeleteOneOrder(entity);

        }

        public Task<List<Order>> GetAllOrdersAsync(bool trackChanges)
        {
            var entities = _orderRepository.GetAllOrdersAsync(trackChanges);
            return entities;
        }

        public async Task<OrderDto> GetOneOrderByIdAsync(int id, bool trackChanges)
        {
            var entity = await OrderCheck(id, trackChanges);
            var dto = _mapper.Map<OrderDto>(entity);
            return dto;
        }

        public async Task UpdateOneOrderAsync(int id, OrderUpdateDto orderDto, bool trackChanges)
        {
            var check = await OrderCheck(id, trackChanges);
            var entity = _mapper.Map<Order>(orderDto);
            entity.OrderId = check.OrderId;
            _orderRepository.UpdateOneOrder(entity);
        }

        private async Task<Order> OrderCheck(int id, bool trackChanges)
        {
            var entity = await _orderRepository.GetOneOrderByIdAsync(id, trackChanges);
            if (entity is null)
                throw new ExceptionBase($"{id} order not found.");

            return entity;
        }
    }
}
