using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketOrder : BaseModel
    {
        public DateTime createdDateTime { get; set; }
        public DateTime updateDateTime { get; set; }
        public long AuthorizationId{get;set;}
        public Authorization authorization { get; set; }
        public DateTime acceptedDateTime { get; set; }
        public bool acceptedStatus { get; set; }
        public bool rejectedStatus { get; set; }
        public String userFullName { get; set; }
        public String orderNumber { get; set; }
        public String Statya { get; set; }
        public String part { get; set; }
        public String codeStr { get; set; }
        public double limitSumm { get; set; }
        public bool orderDeliveriedStatus { get; set; }
        public List<MarketOrderDetail> marketOrderDetails { get; set; }


    }
}
