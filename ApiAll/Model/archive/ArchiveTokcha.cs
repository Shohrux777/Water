using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_tokcha")]
    public class ArchiveTokcha : ArchiveBaseModel
    {
        public String name { get; set; }
        public String note { get; set; }
    }
}
