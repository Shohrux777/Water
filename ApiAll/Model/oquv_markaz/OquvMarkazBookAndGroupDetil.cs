using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_book_and_group_detail")]
    public class OquvMarkazBookAndGroupDetil: OquvMarkazBaseModel
    {
        public long OquvMarkazBookAndGroupid { get; set; }
        public OquvMarkazBookAndGroup group_book { get; set; }
        public long OquvMarkazBookUnitid { get; set; }
        public OquvMarkazBookUnit unit { get; set; }
        public bool readed { get; set; } = false;

    }
}
