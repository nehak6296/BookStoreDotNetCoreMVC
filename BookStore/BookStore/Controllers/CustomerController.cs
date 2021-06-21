﻿using ManagerLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerManager customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }
        [HttpGet]
        public ActionResult GetAllCustomerDetails(int userId)
        {
            try
            {                
                var result = this.customerManager.GetAllCustomerDetails(userId);
                if (result != null)
                {
                    return Json(new { status = true, Message = "Customers details fetched successfully ..!!!", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "No customer present..!!", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }
    }
}
