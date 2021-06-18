using ManagerLayer.Interface;
using ModelsLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Manager
{
    public class WishListManager : IWishListManager
    {
        private readonly IWishListRepo wishListRepo;
        public WishListManager(IWishListRepo wishListRepo)
        {
            this.wishListRepo = wishListRepo;
        }      

        public List<GetWishList> GetWishList()
        {
            return this.wishListRepo.GetWishList();
        }       
    }
}
