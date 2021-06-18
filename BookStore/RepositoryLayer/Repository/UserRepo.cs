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
    public class UserRepo : IUserRepo
    {
        private SqlConnection connection;
        private readonly IConfiguration configuration;
        string connectionString = null;
        //To Handle connection related activities
        public UserRepo(IConfiguration configuration)
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
        public bool LoginUser(Login loginModel)
        {
            try
            {
                //Random random = new Random();
                //random.Next(100000,999999);
                Connection();
                string password = Encryptdata(loginModel.Password);
                SqlCommand cmd = new SqlCommand("sp_LoginUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", loginModel.Email);
                cmd.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i <= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        public Register RegisterUser(Register registrationModel)
        {
            try
            {
                Connection();
                string password = Encryptdata(registrationModel.Password);
                SqlCommand cmd = new SqlCommand("sp_RegisterUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", registrationModel.FirstName);
                cmd.Parameters.AddWithValue("@LastName", registrationModel.LastName);
                cmd.Parameters.AddWithValue("@Email", registrationModel.Email);
                cmd.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i <=1)
                    return registrationModel;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
