using Data_Access_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IConfiguration _configuration;



        public SearchController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult SearchItems(string query)
        {
            string connectionString = _configuration.GetConnectionString("DB");



            string sqlQuery = @"
        SELECT p.ProductId, p.Title, p.Description, p.Price, p.Quantity, p.ImageName, 
               pc.CategoryId, pc.Category, pc.SubCategory FROM Products p
        JOIN ProductCategories pc ON p.CategoryId = pc.CategoryId
        WHERE p.Title LIKE '%' + @Query + '%' OR p.Description LIKE '%' + @Query + '%';";



            List<Product> searchResults = new List<Product>();



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.Add("@Query", SqlDbType.VarChar).Value = query;



                    connection.Open();



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Id = (int)reader["ProductId"],
                                Title = (string)reader["Title"],
                                Description = (string)reader["Description"],
                                Price = (double)reader["Price"],
                                Quantity = (int)reader["Quantity"],
                                ImageName = (string)reader["ImageName"],
                                ProductCategory = new ProductCategory
                                {
                                    Id = (int)reader["CategoryId"],
                                    Category = (string)reader["Category"],
                                    SubCategory = (string)reader["SubCategory"]
                                }
                            };



                            searchResults.Add(product);
                        }
                    }
                }
            }



            return Ok(searchResults);
        }
    }
}
