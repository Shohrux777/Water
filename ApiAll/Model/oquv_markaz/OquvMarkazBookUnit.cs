using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_book_unit")]
    public class OquvMarkazBookUnit : OquvMarkazBaseModel
    {
        public String name { get; set; }
        public String name1 { get; set; }
        public String name2 { get; set; }
        public String name3 { get; set; }
        public String name4 { get; set; }
        public String name5 { get; set; }
        public OquvMarkazBook book { get; set; }
        public long OquvMarkazBookid { get; set; }
    }
}
