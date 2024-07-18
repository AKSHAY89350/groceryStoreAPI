using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class CartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; } = new Product();
    }
}
