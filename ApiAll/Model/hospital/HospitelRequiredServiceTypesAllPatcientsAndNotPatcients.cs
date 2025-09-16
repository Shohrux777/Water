using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAll.Model.market;

namespace ApiAll.Model
{
    public class HospitelRequiredServiceTypesAllPatcientsAndNotPatcients : BaseModel
    {
        public long ServiceTypeId { get; set; }
        public ServiceType serviceType { get; set; }
    }
}
