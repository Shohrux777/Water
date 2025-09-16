using System;
namespace ApiAll.Model
{
    public class DatchikRealValues :BaseModel
    {
        public String SerialNumber { get; set; }
        public String Value { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public long RoomsId { get; set; }
        public Rooms rooms { get; set; }
    }
}
