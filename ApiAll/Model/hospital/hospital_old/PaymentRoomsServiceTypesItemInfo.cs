using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class PaymentRoomsServiceTypesItemInfo : BaseModel
    {
        public long PaymentRoomsServiceTypesItemId  { get; set; }
        public PaymentRoomsServiceTypesItem paymentRoomsServiceTypesItem { get; set; }
        public String Note { get; set; }

        [DefaultValue("getutcdate()")]
        public DateTime RegistretedDateTime { get; set; }
    }
}
