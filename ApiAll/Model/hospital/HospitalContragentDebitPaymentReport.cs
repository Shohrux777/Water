using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class HospitalContragentDebitPaymentReport : BaseModel
    {
        [Column(TypeName = "date")]
        public DateTime createdDate { get; set; }
        public String contragentName { get; set; }
        public String serviceTypeName { get; set; }
        public String contragentPhoneNumber { get; set; }
        public String contragentAddress { get; set; }
        public String regionName { get; set; }
        public String serviceGroupName { get; set; }
        public bool paymentPayedStatus { get; set; }
        public long districtsId { get; set; }
        [ForeignKey("districtsId")]
        public Districts districts { get; set; }
        public long? contragentId{get;set;}

        [ForeignKey("contragentId")]
        public Contragent contragent { get; set; }
        public double? summa { get; set; }
        [NotMapped]
        public String contragent_name => contragent != null ? contragent.Name : "";
        [NotMapped]
        public String district_name => districts != null ? districts.Name : "";

    }
}
