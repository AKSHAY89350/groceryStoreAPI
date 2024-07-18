using Data_Access_Layer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business_Layer
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IConfiguration configuration;
        private readonly string dbconnection;
        private readonly string dateformat;
        public AdminRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            dbconnection = this.configuration["ConnectionStrings:DB"];
            dateformat = this.configuration["Constants:DateFormat"];
        }

        public bool EditProduct(int productId, AddProduct updatedProduct)
        {
            using (SqlConnection connection = new SqlConnection(dbconnection))
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = connection
                };

                string query = "UPDATE Products SET Title = @title, Description = @description, Price = @price, Quantity = @quantity, ImageName = @imageName WHERE ProductId = @productId";
                command.CommandText = query;
                command.Parameters.Add("@productId", System.Data.SqlDbType.Int).Value = productId;
                command.Parameters.Add("@title", System.Data.SqlDbType.NVarChar).Value = updatedProduct.Title;
                command.Parameters.Add("@description", System.Data.SqlDbType.NVarChar).Value = updatedProduct.Description;
                command.Parameters.Add("@price", System.Data.SqlDbType.Float).Value = updatedProduct.Price;
                command.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = updatedProduct.Quantity;
                command.Parameters.Add("@imageName", System.Data.SqlDbType.NVarChar).Value = updatedProduct.ImageName;

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        public bool DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(dbconnection))
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = connection
                };

                string query = "DELETE FROM Products WHERE ProductId = @productId";
                command.CommandText = query;
                command.Parameters.Add("@productId", System.Data.SqlDbType.Int).Value = productId;

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }

        }


        public void AddProduct(AddProduct product)
        {
            using (SqlConnection connection = new SqlConnection(dbconnection))
            {
                connection.Open();

                string query = "INSERT INTO Products (Title, Description, categoryId, OfferId, Price, Quantity, ImageName) " +
                               "VALUES (@Title, @Description, @Categories, @Offer, @Price, @Quantity, @ImageName)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", product.Title);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Categories", product.categories);
                    command.Parameters.AddWithValue("@Offer", product.offer);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);
                    command.Parameters.AddWithValue("@ImageName", product.ImageName);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void EditProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(dbconnection))
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = connection
                };

                string query = "UPDATE Products SET Title = @Title, Description = @Description, Price = @Price, Quantity = @Quantity, ImageName = @ImageName, CategoryId = @CategoryId, OfferId = @OfferId WHERE ProductId = @ProductId";
                command.CommandText = query; command.Parameters.AddWithValue("@Title", product.Title);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Quantity", product.Quantity);
                command.Parameters.AddWithValue("@ImageName", product.ImageName);
                command.Parameters.AddWithValue("@CategoryId", product.ProductCategory.Id);
                command.Parameters.AddWithValue("@OfferId", product.Offer.Id);
                command.Parameters.AddWithValue("@ProductId", product.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

