using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_room_datchik_detail")]
    public class ArchiveRoomDatchikDetail:ArchiveBaseModel
    {
        public String datchik_number { get; set; }
        public String device_number { get; set; }
        public double value { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; } = DateTime.Now;

        [DataType(DataType.Time)]
        public DateTime date_time { get; set; } = DateTime.Now;
        [NotMapped]
        public double min_value { get; set; } = 0.0;
        [NotMapped]
        public double max_value { get; set; } = 0.0;
        [NotMapped]
        public String datchik_name { get; set; }

    }
}
