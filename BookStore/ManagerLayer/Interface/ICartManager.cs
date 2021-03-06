using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface ICartManager
    {       
        List<GetCart> GetCart();
        Cart AddToCart(Cart cartModel);
        int RemoveFromCart(int cartId);

    }

}
