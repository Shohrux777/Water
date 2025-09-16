using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_company")]
    public class ArchiveCompany : ArchiveBaseModel
    {
        [Required]
        public String name { get; set; }
        public String address { get; set; }
        public String note { get; set; }
    }
}
