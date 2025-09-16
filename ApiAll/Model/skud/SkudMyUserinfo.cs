using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_my_user_info")]
    public class SkudMyUserinfo
    {
        [Key]
        public long badgenumber { get; set; }
        public long userid { get; set; }
        public String ism { get; set; }
        public String cardno { get; set; }
        public String familiya { get; set; }
        public long? departid { get; set; }
        public String acc_name { get; set; }
        public int? gr { get; set; } = 0;
        public List<long>? fpid { get; set; }
        public int? status { get; set; }
        public int? without_gr_id { get; set; } = 0;

    }
}
