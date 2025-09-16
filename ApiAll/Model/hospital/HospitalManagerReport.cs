using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class HospitalManagerReport : BaseModel
    {
        public String HospitalServiceTypeGroupName { get; set; }
        public long AuthorizationId{get;set;}
        public Authorization authorization { get; set; }
        public double cashSumm{ get; set; }
        public double cardSumm { get; set; }
        public int status { get; set; }

        [Column(TypeName = "date")]
        public DateTime createdDateTime { get; set; }
        public long count { get; set; }

    }
}
