using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class MarketPrePaidMoney : BaseModel
    {
        public double realSumm { get; set; }
        public double reservedSumm { get; set; }
        public DateTime createdDateTime { get; set; }
        public long UsersId{ get; set; }
        public Users users { get; set; }
        public String note { get; set; }
    }
}
