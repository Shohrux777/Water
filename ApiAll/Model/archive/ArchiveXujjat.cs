using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_xujjat")]
    public class ArchiveXujjat : ArchiveBaseModel
    {
        public String name { get; set; }
        public DateTime yili { get; set; } = DateTime.Now;
        public String note { get; set; }
        public String registration_number { get; set; }
        public String info { get; set; }
    }
}
