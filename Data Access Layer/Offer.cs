﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int Discount { get; set; } = 0;
    }
}
