using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_tortilgan_bugdoy_royxati_group")]
    public class TegirmonTortilganBugdoyRoyxatiGroup : TegirmonBaseModel
    {
        public String name { get; set; }
        public String reverced_str { get; set; }
        public DateTime date_time { get; set; } = DateTime.Now;
        public String car_number { get; set; }
        public String shafyor_name { get; set; }
        public String note { get; set; }
        public double qty { get; set; } = 0.0;
        public double real_qty { get; set; } = 0.0;
        public long reverced_need_id { get; set; } = 0;
        public String qabul_qilgan_user_name { get; set; }
        public List<TegirmonTortilganBugdoyRoyxatiGroupDetail> items { get; set; }
        public bool accepted_status { get; set; } = false;
    }
}
