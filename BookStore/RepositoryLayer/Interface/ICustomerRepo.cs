using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICustomerRepo
    {
        List<Customer> GetAllCustomerDetails(int userId);
    }
}
