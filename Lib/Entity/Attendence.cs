using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Entity
{
    public class Attendence
    {
        [Key,Column(Order=0)]
        public int LessionId { set; get; }
        [Key,Column(Order =1)]
        public int EnrollmentId { set; get; }

        [ForeignKey("LessionId")]
        public Lession Lession { set; get; }
        [ForeignKey("EnrollmentId")]
        public Enrollment Enrollment { set; get; }

        public bool Status { set; get; }
    }
}
