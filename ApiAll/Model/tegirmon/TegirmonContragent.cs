using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_contragent")]
    public class TegirmonContragent : TegirmonBaseModel
    {
        public String name { get; set; }
        public String adddress { get; set; }
        public String passport_number { get; set; }
        public String phone_number { get; set; }
        public String contragent_company_name { get; set; }
        public String note { get; set; }
        public String image_base_64 { get; set; }
        public String image_url { get; set; }
        public String car_number { get; set; }
        public String addiotionala_information { get; set; }
        public int user_face_id { get; set; } = 0;
        public long? TegirmonDistrictid { get; set; }
        public TegirmonDistrict district { get; set; }
        public DateTime created_date { get; set; } = DateTime.Now;
        public DateTime udate_date { get; set; } = DateTime.Now;
        public String passport_image_base_64 { get; set; }
        public String passport_image_url { get; set; }
        public long? bot_id { get; set; }

    }
}
