using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hotel
{
    [Table("hotel_company")]
    public class HotelCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [DefaultValue(true)]
        public bool active_status { get; set; } = true;
        [Required]
        public String name { get; set; }
        public String company_full_name { get; set; }
        public String address { get; set; }
        public String info { get; set; }
        public String phoneNumber { get; set; }
        public String bot_info { get; set; }
        public long? bot_id { get; set; }
    }
}
