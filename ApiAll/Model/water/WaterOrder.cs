using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_order")]
    public class WaterOrder : WaterBaseModel
    {
        public DateTime order_date { get; set; } = DateTime.Now;
        public long WaterClientid{get;set;}
        public WaterClient client { get; set; }

        public long water_count { get; set; } = 0;
        public bool accepted_status { get; set; } = false;
        public DateTime order_accepted_date { get; set; } =  DateTime.Now;
        public List<WaterOrderItem> items { get; set; }

        public WaterClientAddress address { get; set; }
        public long WaterClientAddressid { get; set; }

        public String note { get; set; }

        public WaterUser user { get; set; }
        public long? WaterUserid { get; set; }

        public long? deleivered_user_auth_id { get; set; }

        [NotMapped]
        public String client_name_str => client != null ? client.fio : "";
        [NotMapped]
        public String phone_number_list_arr { get; set; }
        [NotMapped]
        public String color_value { get; set; }
        [NotMapped]
        public double? days_count { get; set; }
        [NotMapped]
        public List<WaterClientPhoneNumber> phone_list_obj { get; set; }
        [NotMapped]
        public String name_pp { get; set; }
        [NotMapped]
        public String name_pp1 { get; set; }
        [NotMapped]
        public String name_pp2 { get; set; }




    }
}
