using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class VozvratAlreadyPaidPaymentList:BaseModel
    {
        public String patientName { get; set; }
        public String SerivceTypeName { get; set; }
        public String ServiceGroupName { get; set; }
        public DateTime dateTime { get; set; }
        public long? paymentCreatorId { get; set; }
        public long? paymentDeletorId { get; set; }
        public long summa { get; set; }
        public String contragentName { get; set; }
    }
}
