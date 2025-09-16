using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_gr_for_emp")]
    public class SkudGrForEmp
    {
        [Key]
        public long id_emp { get; set; }
        public String gr_nomi { get; set; }
        [DataType(DataType.Date)]
        public DateTime _begin { get; set; }

        [DataType(DataType.Date)]
        public DateTime _end { get; set; }

    }
}
