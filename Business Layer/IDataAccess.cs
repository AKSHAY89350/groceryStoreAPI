using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public interface IDataAccess
    {
        List<ProductCategory> GetProductCategories();
        ProductCategory GetProductCategory(int id);
        Offer GetOffer(int id);
        List<Product> GetProducts(string category, string subcategory, int count);
        Product GetProduct(int id);
        bool InsertUser(User user);
        string IsUserPresent(string email, string password);
        void InsertReview(Review review);
        List<Review> GetProductReviews(int productId);
        User GetUser(int id);
        bool InsertCartItem(int userId, int productId);
        Cart GetActiveCartOfUser(int userid);
        Cart GetCart(int cartid);
        List<Cart> GetAllPreviousCartsOfUser(int userid);
        List<PaymentMethod> GetPaymentMethods();
        int InsertPayment(Payment payment);
        int InsertOrder(Order order);

        bool UpdateCartItem(int cartItemId, int newQuantity);
        bool RemoveCartItem(int cartItemId);
    }
}
