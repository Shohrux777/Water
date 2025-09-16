using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketOrderDeliveriedInfo : BaseModel
    {
        public long AuthorizationId { get; set; }
        public Authorization authorization { get; set; }
        public long MarketOrderId{get;set;}
        public MarketOrder marketOrder { get; set; }
        public String Note { get; set; }
        public DateTime dateTime { get; set; }
    }
}
