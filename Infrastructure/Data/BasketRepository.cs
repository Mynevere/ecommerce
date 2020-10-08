using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketContext _basketContext;

        public BasketRepository(BasketContext basketContext)
        {
            _basketContext = basketContext;
        }

        public async Task<bool> DeleteBasket(string basketId)
        {
            var basket = _basketContext.CustomerBaskets.Find(basketId);
            if (basket != null)
            {
                _basketContext.Remove(basket);
                await _basketContext.SaveChangesAsync();
            }
            return false;
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var basketItems = _basketContext.BasketItems.ToListAsync(); 
            for(int i = 0; i < basketItems.Result.Count; i++)
            {
                if(basketItems.Result[i].CustomerBasketId == basketId)
                {
                    var basket = _basketContext.CustomerBaskets.Find(basketId);
                    if (basket != null)
                    {
                        return basket;
                    }
                }
            }
            return null;
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            CustomerBasket created = new CustomerBasket
            {
                Id = basket.Id,
            };

            List<BasketItem> basketItems = basket.Items;

            for (int i = 0; i < basketItems.Count; i++)
            {

                if (_basketContext.BasketItems.Find(basketItems[i].Id) == null) 
                {
                    if(_basketContext.CustomerBaskets.Find(created.Id) == null)
                    {
                        _basketContext.CustomerBaskets.Add(created);
                        basketItems[i].CustomerBasketId = created.Id;    
                        _basketContext.BasketItems.Update(basketItems[i]);
                    }
                    else
                    {
                        basketItems[i].CustomerBasketId = created.Id;
                        _basketContext.BasketItems.AddRange(basketItems[i]);   
                    }
                }
                if(_basketContext.BasketItems.Find(basketItems[i].Id) != null)
                {
                    var item = _basketContext.BasketItems.Find(basketItems[i].Id);
                    item.Quantity = basketItems[i].Quantity;

                    _basketContext.CustomerBaskets.Update(created);
                    _basketContext.BasketItems.Update(item);  
                }
                else { continue; }

            }
            await _basketContext.SaveChangesAsync(); 

            return created;
        }
    }                                    
}
