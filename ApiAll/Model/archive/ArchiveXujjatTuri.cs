using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.archive
{
    [Table("archive_xujjat_turi")]
    public class ArchiveXujjatTuri : ArchiveBaseModel
    {
       public String name { get; set; }
    }
}
