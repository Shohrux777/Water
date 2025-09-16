using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.water
{
    public class WaterBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [DefaultValue(true)]
        public bool active_status { get; set; } = true;
        public DateTime? created_date_time { get; set; } = DateTime.Now;
        public DateTime? updated_date_time { get; set; } = DateTime.Now;

        public long? reserverd_number_id { get; set; } = 0;
        public long? reserverd_number_id_1 { get; set; } = 0;
        public long? reserverd_number_id_2 { get; set; } = 0;
        public long? reserverd_number_id_3 { get; set; } = 0;


        public double? reserverd_numeric_id { get; set; } = 0.0;
        public double? reserverd_numeric_id_1 { get; set; } = 0.0;
        public double? reserverd_numeric_id_2 { get; set; } = 0.0;
        public double? reserverd_numeric_id_3 { get; set; } = 0.0;

        public String reserverd_note { get; set; } 
        public String reserverd_note_1 { get; set; }
        public String reserverd_note_2 { get; set; }
        public String reserverd_note_3 { get; set; }

        [NotMapped]
        public String created_date_time_str => created_date_time != null ? created_date_time?.ToString("HH:mm::ss dd-MM-yyyy ") : "";

        [NotMapped]
        public String updated_date_time_str => updated_date_time != null ? updated_date_time?.ToString("HH:mm::ss dd-MM-yyyy ") : "";

        public bool inv_accepted_status { get; set; } = false;


    }
}
