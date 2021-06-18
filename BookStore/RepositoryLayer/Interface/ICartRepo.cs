using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRepo
    {
        List<GetCart> GetCart();
        int RemoveFromCart(int cartId);
    }
}
