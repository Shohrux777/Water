using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class ContragentAdditionalPaymentBefohandFullInfo : BaseModel
    {
        public long ContragentId{get;set;}
        public Contragent contragent { get; set; }
        public double qtySumm { get; set; }
        public double realQty { get; set; }
        [NotMapped]
        public String contragent_name => contragent != null ? contragent.Name : "";

    }
}
