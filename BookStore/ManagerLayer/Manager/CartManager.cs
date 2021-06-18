﻿using ManagerLayer.Interface;
using ModelsLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Manager
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepo cartRepo;
        public CartManager(ICartRepo cartRepo)
        {
            this.cartRepo = cartRepo;
        }
     
        public List<GetCart> GetCart()
        {
            return this.cartRepo.GetCart();
        }
        public int RemoveFromCart(int cartId)
        {
            return this.cartRepo.RemoveFromCart(cartId);
        }

    }
}
