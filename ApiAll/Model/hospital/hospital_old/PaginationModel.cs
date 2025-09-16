using ApiAll.Model.market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class PaginationModel
    {
        public List<MarketOrder> marketOrdersList { get; set; }
        public List<Users> usersList { get; set; }
        public List<MarketProduct> marketProductList { get; set; }
        public int count { get; set; }
    }
}
