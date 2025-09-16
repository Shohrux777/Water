using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketInvoiceItem:BaseModel
    {
        public long MarketProductId { get; set; }
        public MarketProduct product { get; set; }
        public DateTime exiparedDateTimeBegin { get; set; }
        public DateTime exiparedDateTimeEnd { get; set; }
        public double qty { get; set; }
        public double realQty { get; set; }
        public double unitprice { get; set; }

    }
}
