using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DALIceCream
    {
       
        

        public static List<IceCream> GetProducts()
        {
            try
            {
                SqlConnection conn = DBHelper.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GetAllItems", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //sql datareader read data row by row not in bulk
                SqlDataReader reader = cmd.ExecuteReader();
                List<IceCream> products = new List<IceCream>();
                while (reader.Read())
                {
                    IceCream model = new IceCream();
                    model.IceCreamId = Convert.ToInt32(reader["IceCreamId"]);
                    model.Name = (reader["Name"]).ToString();
                    model.Flavor = (reader["Flavor"]).ToString();
                    model.Description = (reader["Description"]).ToString();
                    model.Price = Convert.ToInt32(reader["Price"]);
                    model.PhotoUrl = (reader["PhotoUrl"].ToString());
                    products.Add(model);
                }
                conn.Close();
                return products;
            }
            //it only give error related to csharp for sql we ave to make new catch block for it
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<IceCream>();

            }


        }

        public static void SaveProduct(IceCream obj)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SP_CreateItem", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Flavor", obj.Flavor);
            cmd.Parameters.AddWithValue("@Description", obj.Description);
            cmd.Parameters.AddWithValue("@Price", obj.Price);
            cmd.Parameters.AddWithValue("@PhotoUrl", obj.PhotoUrl);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public static void UpdateProduct(IceCream obj)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateItem", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IceCreamId", obj.IceCreamId);
            cmd.Parameters.AddWithValue("@Name", obj.Name);
            cmd.Parameters.AddWithValue("@Flavor", obj.Flavor);
            cmd.Parameters.AddWithValue("@Description", obj.Description);
            cmd.Parameters.AddWithValue("@Price", obj.Price);
            cmd.Parameters.AddWithValue("@PhotoUrl", obj.PhotoUrl);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public  static void DeleteProduct(int pid)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteProduct", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IceCreamId", pid);

            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
