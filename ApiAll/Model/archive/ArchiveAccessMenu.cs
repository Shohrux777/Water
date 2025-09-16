using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_menu")]
    public class ArchiveAccessMenu:ArchiveBaseModel
    {
        public String name { get; set; }
        public String url { get; set; }
        public List<ArchiveAccessMenuItem> archiveAccessMenuItems { get; set; }
    }
}
