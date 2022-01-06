using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Entity
{
    public class Lession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LessionId { set; get; }
        public string ClassId { set; get; }
        [ForeignKey("ClassId")]
        public Class Class { set; get; }

        public ICollection<Attendence> Attendences { set; get; }
    }
}
