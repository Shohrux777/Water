using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_device")]
    public class ArchiveDevice:ArchiveBaseModel
    {
        [Required]
        public String name { get; set; }
        [Required]
        public String ip { get; set; }
        public int port { get; set; } = 5005;
        public int password { get; set; } = 0;
        public String type { get; set; }

    }
}
