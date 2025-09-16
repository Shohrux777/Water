using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class ServiceTypeDetail: BaseModel
    {
        public long UsersId { get; set; } 
        public Users users { get; set; }
        public long ServiceTypeId { get; set; } 
        public ServiceType serviceType { get; set; }

    }
}
