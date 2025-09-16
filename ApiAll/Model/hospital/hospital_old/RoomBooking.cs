using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class RoomBooking : BaseAnalizModel
    {
        public DateTime ReqistratedDateTime { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime UpdatetedDateTime { get; set; }
        public long RoomsId {get;set;}
        public Rooms rooms { get; set; }
        

    }
}
