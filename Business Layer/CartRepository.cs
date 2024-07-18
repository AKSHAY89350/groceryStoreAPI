using Data_Access_Layer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class CartRepository : ICartRepository
    {
        private readonly IConfiguration configuration;
        private readonly string dbconnection;
        private readonly string dateformat;

        public CartRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            dbconnection = this.configuration["ConnectionStrings:DB"];
            dateformat = this.configuration["Constants:DateFormat"];
        }

        
    }
}
