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
   public  class DALDeal
    {
        public static List<Deal> GetAllDeals()
        {
            try
            {
                SqlConnection conn = DBHelper.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GetAllDeals", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();
                List<Deal> deals = new List<Deal>();

                while (reader.Read())
                {
                    Deal model = new Deal();
                    model.DealId = Convert.ToInt32(reader["DealId"]);
                    model.Title = reader["Title"].ToString();
                    model.Price = Convert.ToDecimal(reader["Price"]);
                    model.PosterUrl = reader["PosterUrl"].ToString();
                    model.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                    deals.Add(model);
                }

                conn.Close();
                return deals;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Deal>();
            }
        }

        public static Deal GetDealById(int dealId)
        {
            try
            {
                SqlConnection conn = DBHelper.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_GetDealById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DealId", dealId);

                SqlDataReader reader = cmd.ExecuteReader();
                Deal deal = null;

                if (reader.Read())
                {
                    deal = new Deal();
                    deal.DealId = Convert.ToInt32(reader["DealId"]);
                    deal.Title = reader["Title"].ToString();
                    deal.Price = Convert.ToDecimal(reader["Price"]);
                    deal.PosterUrl = reader["PosterUrl"].ToString();
                    deal.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                }

                conn.Close();
                return deal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static int CreateDeal(Deal deal)
        {
            try
            {
                SqlConnection conn = DBHelper.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_AddDeal", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", deal.Title);
                cmd.Parameters.AddWithValue("@Price", deal.Price);
                cmd.Parameters.AddWithValue("@PosterUrl", deal.PosterUrl ?? (object)DBNull.Value);

                // Get the newly created DealId
                int dealId = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

                return dealId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public static bool UpdateDeal(Deal deal)
        {
            try
            {
                SqlConnection conn = DBHelper.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_UpdateDeal", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DealId", deal.DealId);
                cmd.Parameters.AddWithValue("@Title", deal.Title);
                cmd.Parameters.AddWithValue("@Price", deal.Price);
                cmd.Parameters.AddWithValue("@PosterUrl", deal.PosterUrl ?? (object)DBNull.Value);

                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool DeleteDeal(int dealId)
        {
            try
            {
                SqlConnection conn = DBHelper.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_DeleteDeal", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DealId", dealId);

                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
