using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class ContragentAdditionalPaymentBefohand : BaseModel
    {
        public String noteStr { get; set; }
        public long ContragentId { get; set; }
        public Contragent contragent { get; set; }
        public String PayedUserInfo { get; set; }
        public long AuthorizationId{get;set;}
        public Authorization authorization { get; set; }
        public DateTime createdDateTime { get; set; }
        public double summa { get; set; }
        [NotMapped]
        public String contragent_name => contragent != null ? contragent.Name : "";
    }
}
