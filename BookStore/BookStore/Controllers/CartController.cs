using ManagerLayer.Interface;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult RemoveFromCart(int cartId)
        {
            try
            {
                var result = this.cartManager.RemoveFromCart(cartId);
                if (result > 0)
                {
                    //return View();
                    return Json(new { status = true, Message = "Book removed from cart", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Failed to Remove", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
