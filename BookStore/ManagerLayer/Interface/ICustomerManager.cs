using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface ICustomerManager
    {       
        List<Customer> GetAllCustomerDetails(int userId);
        Customer AddCustomerDetails(Customer customer);
        Customer UpdateCustomerDetails(Customer customer);

    }
}
