using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; } = new User();
        public List<CartItem> CartItems { get; set; } = new();
        public bool Ordered { get; set; }
        public string OrderedOn { get; set; } = string.Empty;
    }
}
