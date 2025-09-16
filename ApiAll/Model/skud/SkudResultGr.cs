using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_result_gr")]
    public class SkudResultGr
    {
        [DataType(DataType.Time)]
        public DateTime? ish_b { get; set; }

        [DataType(DataType.Time)]
        public DateTime? ish_t { get; set; }

        [DataType(DataType.Time)]
        public DateTime? obed_b { get; set; }

        [DataType(DataType.Time)]
        public DateTime? obed_t { get; set; }

        [DataType(DataType.Time)]
        public DateTime? kech_keldi { get; set; }

        [DataType(DataType.Time)]
        public DateTime? vox_ketdi { get; set; }
        public String g_nomi { get; set; }
        public int? kun_nomi { get; set; }


    }
}
