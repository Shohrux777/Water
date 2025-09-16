using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketInvoice : BaseModel
    {
        public long CompanyId { get; set; }
        public Company company { get; set; }
        public long MarketAgentId { get; set; }
        public MarketAgent agent { get; set; }
        public long AuthorizationId { get; set; }
        public Authorization authorization { get; set; }
        public String InvoceNumber { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime updateDateTime { get; set; }
        public String Note { get; set; }
        public List<MarketNeedToPayToAgents> MarketNeedToPays { get; set; }
        public List<MarketInvoiceItem> marketInvoiceItems { get; set; }

        

    }
}
