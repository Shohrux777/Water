using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketOrderDetail : BaseModel
    {
        public long MarketOrderId { get; set; }
        public MarketOrder marketOrder { get; set; }
        public long MarketProductId { get; set; }
        public MarketProduct product { get; set; }
        public double qty { get; set; }
        public double realQty { get; set; }
        public long summ{ get; set; }
        public long discountSumm { get; set; }
        public String productName { get; set;}
        public String productCode { get; set; }
        public String productUnitMeasurmentName { get; set; }
        public long productPrice { get; set; }
        public DateTime dateTime { get; set; }
    }
}
