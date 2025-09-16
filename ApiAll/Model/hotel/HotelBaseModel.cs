using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.hotel
{
    public class HotelBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [DefaultValue(true)]
        public bool active_status { get; set; } = true;
        public long company_id { get; set; }
        public DateTime created_date_time { get; set; } = DateTime.Now;
       
    }
}
