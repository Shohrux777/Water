using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAll.Model.oquv_markaz
{
    [Table("oquv_markaz_book_and_group")]
    public class OquvMarkazBookAndGroup : OquvMarkazBaseModel
    {
        public long OquvMarkazBookid  { get; set; }
        public OquvMarkazBook book { get; set; }
        public OquvMarkazPupilGroups group{ get; set; }
        public long OquvMarkazPupilGroupsid { get; set; }
        public List<OquvMarkazBookAndGroupDetil> item_list { get; set; }
    }
}
