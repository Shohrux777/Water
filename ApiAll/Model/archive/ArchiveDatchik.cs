using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_datchik")]
    public class ArchiveDatchik:ArchiveBaseModel
    {
        [Required]
        public String name { get; set; }
        [Required]
        public String code { get; set; }
        public  double min_value { get; set; } = 0.0;
        public double max_value { get; set; } = 0.0;
        
    }
}
