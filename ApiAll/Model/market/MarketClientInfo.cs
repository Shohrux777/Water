using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketClientInfo : BaseModel
    {
        public String userFullName { get; set; }
        public String Statya { get; set; }
        public String part { get; set; }
        public String codeStr { get; set; }
        public long AuthorizationId{get;set;}
        public Authorization authorization { get; set; }
    }
}
