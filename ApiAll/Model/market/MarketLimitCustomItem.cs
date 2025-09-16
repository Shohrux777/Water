using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAll.Model.market;

namespace ApiAll.Model
{
    public class MarketLimitCustomItem
    {
        public long? id { get; set; }
        public long? auth_id { get; set; }
        public String? auth_name { get; set; }
        public DateTime? begin_date { get; set; }
        public DateTime? end_date { get; set; }
        public long? product_id { get; set; }
        public String? product_name { get; set; }
        public double? limit_qty { get; set; }
        public double? real_qty { get; set; }
        public double? realSumm { get; set; }
        public double? reservedSumm { get; set; }
        public bool? limitFinished { get; set; }
        public bool? byProduct { get; set; }

    }
}
