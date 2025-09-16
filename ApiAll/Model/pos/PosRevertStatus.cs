using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.pos
{
    [Table("pos_revert_status")]
    public class PosRevertStatus:PosBaseModel
    {
        [Required]
        public String name { get; set; }
        public int status { get; set; }
        //Списания товары 1
        //Возврат товары  2
        //Возврат от пакупатели  3
    }
}
