using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class ContragentServiceTypeBonusAdditanaly : BaseModel
    {
        public long ContragentId { get; set; }
        public Contragent contragent { get; set; }
        public long ServiceTypeId{get;set;}
        public ServiceType serviceType { get; set; }
        public double bonusSumm { get; set; }
        [NotMapped]
        public String contragent_name => contragent != null ? contragent.Name : "";
        [NotMapped]
        public String service_type_name => serviceType != null ? serviceType.Name : "";
    }
}
