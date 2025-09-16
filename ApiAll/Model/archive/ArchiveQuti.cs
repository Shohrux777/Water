using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_quti")]
    public class ArchiveQuti : ArchiveBaseModel
    {
        public String name { get; set; }
        public String note { get; set; }
        public String number { get; set; }
        public String info { get; set; }
    }
}
