using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_room_detail")]
    public class ArchiveRoomDetail : ArchiveBaseModel
    {
        public ArchiveRoom room { get; set; }
        public long ArchiveRoomid { get; set; }
        public ArchiveDatchik datchik { get; set; }
        public long ArchiveDatchikid { get; set; }

        [NotMapped]
        public String room_name => room != null ? room.name : "";

        [NotMapped]
        public String datchik_name => datchik != null ? datchik.name : "";
    }
}
