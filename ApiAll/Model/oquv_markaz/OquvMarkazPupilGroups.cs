using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_pupil_groups")]
    public class OquvMarkazPupilGroups:OquvMarkazBaseModel
    {
        public String name { get; set; }
        public String note { get; set; }
        public String info { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan begin_time { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan end_time { get; set; }
        public bool finish_group { get; set; } = false;
        public long OquvMarkazUserid { get; set; }
        public OquvMarkazUser user { get; set; }
        public long OquvMarkazFanlarid { get; set; }
        public OquvMarkazFanlar fan { get; set; }
        public List<int> week_days { get; set; }
        [Column(TypeName = "date")]
        public DateTime gruppa_opened_date { get; set; } = DateTime.Now;
        public bool opened_group_status { get; set; } = false;
        public long count_of_lessons_in_month { get; set; } = 0;

        [NotMapped]
        public String user_fio => user != null ? user.fio : "";

        [NotMapped]
        public String fan_name => fan != null ? fan.name : "";

        [NotMapped]
        public int oquvchi_soni { get; set; } = 0;
    }
}
