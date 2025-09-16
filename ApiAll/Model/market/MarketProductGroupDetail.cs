
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ApiAll.Model.market
{
    public class MarketProductGroupDetail : BaseModel
    {
        public long MarketProductId { get;set;}
        public MarketProduct product { get; set; }
        public long MarketProductGroupId {get;set;}
        public MarketProductGroup marketProductGroup { get; set; }
        [NotMapped]
        public MarketProductRealQty marketProductRealQty { get; set; }
        [NotMapped]
        public MarketAuthLimitByProduct marketAuthLimitByProduct { get; set; }

    }
}