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
                if(basket.Items.Count == 0)
                {
                    var items = _basketContext.BasketItems.Where(x => x.CustomerBasketId == basketId);
                    _basketContext.BasketItems.RemoveRange(items);
                }
                _basketContext.CustomerBaskets.Remove(basket);
                await _basketContext.SaveChangesAsync();

                return true; 
            }
            return false;
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var basketItems = await _basketContext.BasketItems.ToListAsync(); 
            for(int i = 0; i < basketItems.Count; i++)
            {
                if(basketItems[i].CustomerBasketId == basketId)
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
                DeliveryMethodId = basket.DeliveryMethodId,
                ClientSecret = basket.ClientSecret,
                PaymentIntentId = basket.PaymentIntentId,
                ShippingPrice = basket.ShippingPrice
            };

            for (int i = 0; i < basket.Items.Count; i++)
            {
                if (_basketContext.BasketItems.Find(basket.Items[i].Id) == null) 
                {
                    if(_basketContext.CustomerBaskets.Find(created.Id) == null)
                    {
                        _basketContext.CustomerBaskets.Add(created);
                        basket.Items[i].CustomerBasketId = created.Id;    
                        _basketContext.BasketItems.Update(basket.Items[i]);
                    }
                    else
                    {
                        basket.Items[i].CustomerBasketId = created.Id;
                        _basketContext.BasketItems.AddRange(basket.Items[i]);   
                    }
                }
                if(_basketContext.BasketItems.Find(basket.Items[i].Id) != null)
                {
                    var item = _basketContext.BasketItems.Find(basket.Items[i].Id);
                    item.Quantity = basket.Items[i].Quantity;

                    foreach (var currentItem in _basketContext.BasketItems.Where(x => x.CustomerBasketId == created.Id).ToList())
                    {
                        if (!basket.Items.Any(item => item.Id == currentItem.Id))   
                        {
                            _basketContext.BasketItems.Remove(currentItem); 
                        }
                    }
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
