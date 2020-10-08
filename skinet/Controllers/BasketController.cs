using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc;
using skinet.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skinet.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly BasketContext _basketContext;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, BasketContext basketContext, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _basketContext = basketContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            CustomerBasket newBasket = null;

            if (basket == null) {
                newBasket = new CustomerBasket(id);
                await _basketContext.SaveChangesAsync();
            }

            return Ok(basket ?? newBasket);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);

            var updatedBasket = await _basketRepository.UpdateBasketAsync(customerBasket);

            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _basketRepository.DeleteBasket(id);   
        }
    }
}
