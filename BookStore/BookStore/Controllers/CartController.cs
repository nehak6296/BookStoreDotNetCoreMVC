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
    }
}
