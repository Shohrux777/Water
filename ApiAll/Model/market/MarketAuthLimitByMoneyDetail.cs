using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketAuthLimitByMoneyDetail : BaseModel
    {
        public DateTime dateTime { get; set; }
        public double summ { get; set; }
        public long MarketAuthLimitByMoneyId{get;set;}
        public MarketAuthLimitByMoney LimitByMoney { get; set; }
        public long MarketOrderId { get; set; }
        public MarketOrder marketOrder { get; set; }
    }
}
