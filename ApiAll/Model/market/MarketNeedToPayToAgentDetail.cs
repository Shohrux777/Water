using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketNeedToPayToAgentDetail : BaseModel
    {
        public long MarketNeedToPayToAgentsId { get; set; }
        public MarketNeedToPayToAgents NeedToPayToAgents { get; set; }
        public double summ { get; set; }
        public String paymentTypeStr { get; set; }
        public DateTime dateTime { get; set; }
        public long AuthorizationId {get;set;}
        public Authorization authorization { get; set; }
    }
}
