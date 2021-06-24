using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IOrdersManager
    {
        Orders Checkout(Orders orders);

    }
}
