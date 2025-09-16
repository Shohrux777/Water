using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_client")]
    public class TegirmonClient : TegirmonBaseModel
    {
        public String fio { get; set; }
        public String adddress { get; set; }
        public String passport_number { get; set; }
        public String phone_number { get; set; }
        public String home_phone_number { get; set; }
        public String note { get; set; }
        public String image_base_64 { get; set; }
        public String image_url { get; set; }
        public String car_number { get; set; }
        public String addiotionala_information { get; set; }
        public int user_face_id { get; set; } = 0;
        public long? TegirmonDistrictid { get; set; }
        public TegirmonDistrict district { get; set; }
        public long? TegirmonClientGroupid { get; set; }
        public TegirmonClientGroup group { get; set; }
        public DateTime created_date { get; set; } = DateTime.Now;
        public DateTime udate_date { get; set; } = DateTime.Now;
        public String passport_image_base_64 { get; set; }
        public String passport_image_url { get; set; }
        public long? bot_id { get; set; }
        public String reserve { get; set; }
        public double reserve_val { get; set; } = 0.0;
        public long reserve_val_l { get; set; } = 0;
       

        
    }
}
