using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class HospitalServiceTypeByGroupPermission : BaseModel
    {
      public long HospitalServiceTypeGroupId { get; set; }
      public HospitalServiceTypeGroup ServiceTypeGroup { get; set; }
      public bool withoutReturnStatus { get; set; }

    }
}
