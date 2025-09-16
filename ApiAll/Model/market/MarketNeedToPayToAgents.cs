using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketNeedToPayToAgents : BaseModel
    {
        public long MarketInvoiceId { get; set; }
        public MarketInvoice marketInvoice { get; set; }
        public double summ { get; set; }
        public double realSumm { get; set; }
        public String note { get; set; }
        public DateTime dateTime { get; set; }
        public long MarketAgentId { get; set; }
        public MarketAgent marketAgent { get; set; }
        public long AuthorizationId{get;set;}
        public Authorization createdUser { get; set; }
    }
}

