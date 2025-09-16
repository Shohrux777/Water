using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketProductRealQtyTemp : BaseModel
    {
        public long MarketOrderDetailId { get; set; }
        public MarketOrderDetail marketOrderDetail { get; set; }
        public long MarketProductId { get;set;}
        public MarketProduct product { get; set; }
        public double qty { get; set; }
        
    }
}
