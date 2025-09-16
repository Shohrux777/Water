using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_menu_item")]
    public class ArchiveAccessMenuItem:ArchiveBaseModel
    {
        public ArchiveAccessMenu accessMenu { get; set; }
        public long ArchiveAccessMenuid { get; set; }
        public String name { get; set; }
        public String url { get; set; }
    }
}  
