using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAll.Model.skud
{
    [Table("skud_picture_checkinout")]
    public class SkudPictureCheckinout
    {
        public long? userid { get; set; }
        [DataType(DataType.Date)]
        public DateTime sana { get; set; }

        [DataType(DataType.Time)]
        public DateTime checktime { get; set; }
        public byte? rasm { get; set; }
    }
}
