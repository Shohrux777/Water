using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketProductGroupAndProducts:BaseModel
    {
        public List<MarketProductGroupDetail> marketProductGroupDetailList { get; set; }
        public List<MarketProductGroup> marketProductGroupList { get; set; }
    }
}
