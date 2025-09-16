using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.market
{
    public class MarketAgent : BaseModel
    {
        public String fullName { get; set; }
        public String phoneNumber { get; set; }
        public String companyName { get; set; }
        public String code { get; set; }
        public String image { get; set; }
        public String specialCode { get; set; }
        public DateTime  ? bornDateTime { get; set; }
             
    }
}
