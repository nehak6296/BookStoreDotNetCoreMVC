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
   public class BookRepo:IBookRepo
    {
        private SqlConnection connection;
        private readonly IConfiguration configuration;
        string connectionString = null;
        //To Handle connection related activities
        public BookRepo(IConfiguration configuration)
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
        public List<Books> GetAllBooks()
        {
            try
            {
                Connection();
                List<Books> BookList = new List<Books>();
                SqlCommand cmd = new SqlCommand("sp_GetAllBooks", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                connection.Open();
                da.Fill(dt);
                connection.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    BookList.Add(
                        new Books
                        {
                            BookId = Convert.ToInt32(dr["BookId"]),
                            BookName = Convert.ToString(dr["BookName"]),
                            Author = Convert.ToString(dr["Author"]),
                            Details = Convert.ToString(dr["Details"]),
                            Price = Convert.ToDouble(dr["Price"]),
                            Quantity = Convert.ToInt32(dr["Quantity"]),
                            Image = Convert.ToString(dr["Image"])

                        }
                        );
                }
                return BookList;
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
