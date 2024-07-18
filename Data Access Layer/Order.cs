using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; } = new User();
        public Cart Cart { get; set; } = new Cart();
        public Payment Payment { get; set; } = new Payment();
        public string CreatedAt { get; set; } = string.Empty;
    }
}
