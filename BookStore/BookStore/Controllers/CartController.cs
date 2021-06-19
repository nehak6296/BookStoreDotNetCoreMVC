﻿using ManagerLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager cartManager;
        public CartController(ICartManager cartManager)
        {
            this.cartManager = cartManager;
        }
        //GET: Cart       
        [HttpGet]
        public ActionResult GetCart()
        {
            try
            {
                var result = this.cartManager.GetCart();               
                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public JsonResult AddToCart([FromBody]Cart cart)
        {
            try
            {
                var result = this.cartManager.AddToCart(cart);
                if (result != null)
                {
                    return Json(new { status = true, Message = "Book added to cart", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Book not added to cart", Data = result });
                }
            }
            catch (Exception)
            {
                return ViewBag.Message = "sucessfully";
            }
        }


       
    }
}
