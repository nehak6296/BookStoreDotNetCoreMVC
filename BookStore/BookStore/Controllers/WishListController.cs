using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishListManager wishListManager;
        public WishListController(IWishListManager wishListManager)
        {
            this.wishListManager = wishListManager;
        }
        // GET: WishList

        [HttpGet]
        public ActionResult GetWishList()
        {
            try
            {
                var result = this.wishListManager.GetWishList();
                ViewBag.Message = "";
                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
