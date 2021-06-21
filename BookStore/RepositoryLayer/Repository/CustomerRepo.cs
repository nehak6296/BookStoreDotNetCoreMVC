using Microsoft.Extensions.Configuration;
using ModelsLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private SqlConnection connection;
        private readonly IConfiguration configuration;
        string connectionString = null;
        //To Handle connection related activities
        public CustomerRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        private void Connection()
        {
            try
            {
                connectionString = configuration.GetSection("ConnectionStrings").GetSection("ConnectionString").Value;
                connection = new SqlConnection(connectionString);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public List<Customer> GetAllCustomerDetails(int userId)
        {
            try
            {
                Connection();
                List<Customer> customerList = new List<Customer>();
                SqlCommand cmd = new SqlCommand("sp_GetAllCustomerDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                connection.Open();
                da.Fill(dt);
                connection.Close();
                //Bind CustomerModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    customerList.Add(
                        new Customer
                        {
                            CustomerId = Convert.ToInt32(dr["CustomerId"]),
                            UserId = Convert.ToInt32(dr["UserId"]),
                            Name = Convert.ToString(dr["Name"]),
                            Address = Convert.ToString(dr["Address"]),
                            Locality = Convert.ToString(dr["Locality"]),
                            Landmark = Convert.ToString(dr["Landmark"]),
                            Pincode = Convert.ToInt32(dr["Pincode"]),
                            PhoneNumber = Convert.ToInt32(dr["PhoneNumber"]),
                            City = Convert.ToString(dr["City"]),
                            Type = Convert.ToString(dr["Type"])
                        }
                        );
                }
                return customerList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
