using ManagerLayer.Interface;
using ModelsLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Manager
{
    public class OrdersManager : IOrdersManager
    {
        private readonly IOrdersRepo ordersRepo;
        public OrdersManager(IOrdersRepo ordersRepo)
        {
            this.ordersRepo = ordersRepo;
        }
        public Orders Checkout(Orders orders)
        {
            return this.ordersRepo.Checkout(orders);
        }

    }
}
