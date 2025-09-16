using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketAuthLimitByProduct : BaseModel
    {
        public long AuthorizationId { get; set; }
        public Authorization authorization { get; set; }
        public DateTime beginDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public long MarketProductId { get;set;}
        public MarketProduct product { get; set; }
        public double qty { get; set;}
        public double realQty { get; set; }
        public bool limitFinished { get; set; }
        public List<MarketAuthLimitByProductDetail> marketAuthLimitByProductDetails { get; set; }

    }
}
