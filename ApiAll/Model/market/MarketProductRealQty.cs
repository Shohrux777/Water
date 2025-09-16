using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketProductRealQty : BaseModel
    {
        public double qty { get; set; }
        public double realQty { get; set; }
        public long MarketProductId { get;set;}
        public MarketProduct product { get; set; }
        public double? minValue { get; set; }
        
        
    }
}
