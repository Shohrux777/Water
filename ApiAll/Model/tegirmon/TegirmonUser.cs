using System;
namespace ApiAll.Model.tegirmon
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tegirmon_user")]
    public class TegirmonUser : TegirmonBaseModel
    {
        public long TegirmonDepartmentid { get; set; }
        public TegirmonDepartment department { get; set; }
        public String fio { get; set; }
        public String phone_number { get; set; }
        public String address { get; set; }
        public String born_date { get; set; }
        public String image_base_64 { get; set; }
        public String image_url { get; set; }
        public String passport_image_base_64 { get; set; }
        public String passport_image_url { get; set; }
        public String car_number { get; set; }
        public String card_number { get; set; }
        public double salary { get; set; } = 0.0;
        public long user_face_id { get; set; } = 0;
        public long? bot_id { get; set; }
      
    }
}
