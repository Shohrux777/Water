using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_revert")]
    public class PosRevert : PosBaseModel
    {
        public long? postavshik_id { get; set; }
        [ForeignKey("postavshik_id")]
        public PosCompany postavshik { get; set; }
        public int revert_status { get; set; } = 0;
        public String note { get; set; }
        [Column(TypeName = "date")]
        public DateTime revert_date { get; set; }
        public List<PosRevertItem> items_list { get; set; }
        public double summ { get; set; } = 0.0;
        public bool applayment_status { get; set; } = false;
        [Column(TypeName = "date")]
        public DateTime reg_date { get; set; } = DateTime.Now;
        [NotMapped]
        public String company_name => postavshik != null ? postavshik.name : "";
        public String registarted_date_str => reg_date != null ? reg_date.Date.ToString("dd-MM-yyyy") : "-----";
        

    }
}
