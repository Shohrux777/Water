using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketProductGroup : BaseModel
    {
        public String Name { get; set; }
        public String PictureStr { get; set; }
        public long? MarketProductGroupId {get;set;}
        public MarketProductGroup marketProductGroup { get; set; }
        public bool MainProductGroup { get;set; }

    }
}
