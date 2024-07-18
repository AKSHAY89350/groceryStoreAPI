using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public interface IAdminRepository
    {
        void AddProduct(AddProduct product);
        bool EditProduct(int productId, AddProduct updatedProduct);
          bool DeleteProduct(int productId);
        public void EditProduct(Product product);

    }
}
