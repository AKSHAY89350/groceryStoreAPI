﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ProductCategory ProductCategory { get; set; } = new ProductCategory();
        public Offer Offer { get; set; } = new Offer();
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImageName { get; set; } = string.Empty;
    }
}
