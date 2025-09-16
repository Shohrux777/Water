using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    [Table("water_client")]
    public class WaterClient : WaterBaseModel
    {
        public int clinet_number { get; set; } = 0;
        public String fio { get; set; }
        public String note { get; set; }
        public String note1 { get; set; }
        public String note2 { get; set; }
        public String note3 { get; set; }
        public String note4 { get; set; }
        public String phone_number { get; set; }
        public String phone_number1 { get; set; }
        public String phone_number2 { get; set; }
        public String phone_number3 { get; set; }
        public WaterTuman tuman { get; set; }
        public long? WaterTumanid { get; set; }
        public String card_number { get; set; }
        public bool client_active { get; set; } = false;
        public long? bot_id { get; set; } = 0;
        public List<WaterClientAddress> addresses { get; set; }
        public List<WaterClientPhoneNumber> phone_numbers_list { get; set; }

        [NotMapped]
        public WaterClientAddress first_address => (addresses != null && addresses.Count > 0) ? addresses[0] : null;

        [NotMapped]
        public String first_address_name => (addresses != null && addresses.Count > 0) ? addresses[0].address : "";

        [NotMapped]
        public WaterClientPhoneNumber first_phone_number => (phone_numbers_list != null && phone_numbers_list.Count > 0) ? phone_numbers_list[0] : null;

        [NotMapped]
        public String first_phone_number_name => (phone_numbers_list != null && phone_numbers_list.Count > 0) ? phone_numbers_list[0].phone_number : "";

        [NotMapped]
        public List<WaterOrder> order_list_for_report_desc { get; set; }

        [NotMapped]
        public List<WaterOrderItem> order_item_list_for_report_desc { get; set; }
        [NotMapped]
        public List<WaterOrder> last_order_list { get; set; }
        [NotMapped]
        public WaterOrder last_order_of_client { get; set; }
        
    }
}
