using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IOrdersRepo
    {
        Orders Checkout(Orders orders);

    }
}
