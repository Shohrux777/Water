using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ApiAll.Model.market
{
    public class MarketProductPrice : BaseModel
    {
        public long MarketProductId { get; set; }
        public MarketProduct product { get; set; }
        public bool discountStatus { get; set; }
        public double price { get; set; }
        public double discountPrice { get; set; }
        public DateTime dateTime { get; set; }
        public long? AuthorizationId { get; set; }
        public Authorization authorization { get; set; }

    }
}
