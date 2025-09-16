using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketAuthLimitByMoney : BaseModel
    {
        public long AuthorizationId{get;set;}
        public Authorization authorization { get; set; } 
        public DateTime beginDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public double realSumm { get; set; }
        public double reservedSumm { get; set; }
        public bool limitFinished { get; set; }
        [NotMapped]
        public double? paidRealSumm { get; set; } = 0;
        public List<MarketAuthLimitByMoneyDetail> marketAuthLimitByMoneyDetails { get; set; }

    }
}
