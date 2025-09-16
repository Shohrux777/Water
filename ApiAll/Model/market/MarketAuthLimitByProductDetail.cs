using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketAuthLimitByProductDetail:BaseModel
    {
    
        public DateTime dateTime { get; set; }
        public double qty { get; set; }
        public long MarketAuthLimitByProductId { get; set; }
        public MarketAuthLimitByProduct LimitByProduct { get; set; }
        public long MarketOrderId { get; set; }
        public MarketOrder marketOrder { get; set; }
    }
}
