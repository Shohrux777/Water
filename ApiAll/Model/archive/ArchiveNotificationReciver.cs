using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.archive
{

    [Table("archive_notify_reciver")]
    public class ArchiveNotificationReciver : ArchiveBaseModel
    {
        [Required]
        public String fio { get; set; }
        [Required]
        public String phone_number { get; set; }
        public long? bot_id { get; set; }
 
    }
}
