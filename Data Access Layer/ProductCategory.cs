﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Category { get; set; } = "";
        public string SubCategory { get; set; } = "";
    }
}
