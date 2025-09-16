using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_company")]
    public class TegirmonCompany : TegirmonBaseModel
    {
        public String name { get; set; }
        public String phone_number { get; set; }
        public long? bot_id { get; set; }
    }
}
