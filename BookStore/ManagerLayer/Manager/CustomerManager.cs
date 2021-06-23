﻿using ManagerLayer.Interface;
using ModelsLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Manager
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepo customerRepo;
        public CustomerManager(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        public List<Customer> GetAllCustomerDetails(int userId)
        {
            return this.customerRepo.GetAllCustomerDetails(userId);
        }
        public Customer AddCustomerDetails(Customer customer)
        {
            return this.customerRepo.AddCustomerDetails(customer);
        }
        public Customer UpdateCustomerDetails(Customer customer)
        {
            return this.customerRepo.UpdateCustomerDetails(customer);
        }
    }
}
