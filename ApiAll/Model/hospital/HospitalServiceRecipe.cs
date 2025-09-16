using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAll.Model.market;

namespace ApiAll.Model
{
    public class HospitalServiceRecipe:BaseModel
    {

        public long ServiceTypeId  { get; set; }
        public ServiceType serviceType { get; set; }
        public long MarketProductId { get; set; }
        public MarketProduct marketProduct { get; set; }
        public double qty { get; set; }

    }
}
