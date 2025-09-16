using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class HospitalContragentNotifierReport : BaseModel
    {
        public long ContragentId{get;set;}
        public Contragent contragent { get; set; }
        public int notActiveDays { get; set; }
        [NotMapped]
        public String contragent_name => contragent != null ? contragent.Name : "";
    }
}
