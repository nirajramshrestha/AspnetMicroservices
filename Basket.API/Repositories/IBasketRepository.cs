﻿using Basket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBaskec(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart Basket);
        Task DeleteBasket(string userName);
    }
}
