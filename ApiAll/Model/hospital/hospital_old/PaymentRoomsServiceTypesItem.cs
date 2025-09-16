using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class PaymentRoomsServiceTypesItem : BaseAnalizModel
    {
        public long PaymentRoomsId { get; set; }
        public PaymentRooms paymentRooms { get; set; }
        public long ServiceTypeId{get;set;}
        public ServiceType serviceType{ get; set; }
        public String ServiceTypeName { get; set; }
        public String PatientName { get; set; }
        public long RealCountService { get; set; }
        public long UsedCountService { get; set; }
        public long Summ { get; set; }
        public List<PaymentRoomsServiceTypesItemInfo> paymentRoomsServiceTypesItemInfoList { get; set; }
    }
}
