using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class PaymentRooms : BaseAnalizModel
    {
        [DefaultValue("getutcdate()")]
        public DateTime RegistretedDateTime { get; set; }
        public long RoomsId { get; set; }
        public Rooms rooms { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public long Summ { get; set; }
        public List<PaymentRoomsItem> paymentRoomsItemsList { get; set; }
        public DateTime BeginBookRoomDateTime { get; set; }
        public DateTime EndBookRoomDateTime { get; set; }

    }
}
