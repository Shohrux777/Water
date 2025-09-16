using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_room")]
    public class ArchiveRoom:ArchiveBaseModel
    {
        public String name { get; set; }
        public String note { get; set; }
        public String info_1 { get; set; }
        public String info_2 { get; set; }
        public String info_3 { get; set; }
        public String info_4 { get; set; }
        public String info_5 { get; set; }
        public String info_6 { get; set; }
        public String info_7 { get; set; }
        public String info_8 { get; set; }
        public String info_9 { get; set; }
        public String info_10 { get; set; }
        public String info_11 { get; set; }
        public String info_12 { get; set; }
        public String info_13 { get; set; }
        public String info_14 { get; set; }
        public String info_15 { get; set; }
        public String info_16 { get; set; }
        public String info_17 { get; set; }
        public String info_18 { get; set; }
        public String info_19 { get; set; }
        public String info_20 { get; set; }
        public String info_21 { get; set; }
        public String info_22 { get; set; }
        public String info_23 { get; set; }
        public List<ArchiveRoomDetail> roomDetails { get; set; }
        [NotMapped]
        public List<ArchiveRoomDatchikDetail> datchikDataList { get; set; }
    }
}
