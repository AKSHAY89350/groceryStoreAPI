using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class Review
    {
        public int Id { get; set; }
        public User User { get; set; } = new User();
        public Product Product { get; set; } = new Product();
        public string Value { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
    }
}
