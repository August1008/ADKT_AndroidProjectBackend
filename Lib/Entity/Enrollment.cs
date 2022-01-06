using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Entity
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { set; get; }
        public string StudentId { set; get; }
        public string ClassId { set; get; }

        [ForeignKey("StudentId")]
        public Student Student { set; get; }

        [ForeignKey("ClassId")]
        public Class Class { set; get; }

        public ICollection<Attendence> Attendences { set; get; }
    }
}
