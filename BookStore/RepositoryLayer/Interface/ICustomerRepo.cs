using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICustomerRepo
    {
        List<Customer> GetAllCustomerDetails(int userId);
        Customer AddCustomerDetails(Customer customer);
        Customer UpdateCustomerDetails(Customer customer);

    }
}
