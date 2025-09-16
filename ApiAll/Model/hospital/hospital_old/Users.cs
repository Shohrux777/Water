using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model
{
    public class Users : BaseModel
    {
        public String FIO { get; set; }
        public String PhoneNumber { get; set; }
        public String Image { get; set; }
        public long? RoomId { get; set; }
        public Rooms rooms { get; set; }
        public long DepartmenId { get; set; }
        public Department department { get; set; }
        public long? PositionId { get; set; }
        public Position position { get; set; }
        public int PolType { get; set; }
        [NotMapped]
        public bool? jailPerson { get; set; }
        [NotMapped]
        public Authorization authorization { get; set; }
        public long? userRegistratedBotId { get; set; }

    }
}
