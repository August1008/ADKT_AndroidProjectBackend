using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Entity
{
    public class Class
    {
        [Key]
        [StringLength(10)]
        public string ClassId { set; get; }

        [StringLength(255)]
        public string Subject { set; get; }
        public DateTime startDate { set; get; }
        public DateTime endDate { set; get; }

        [ForeignKey("Teacher")]
        public string TeacherId { set; get; }
        public Teacher Teacher { set; get; }

        public ICollection<Enrollment> Enrollments { set; get; }

        public ICollection<Lession> Lessions { set; get; }

    }
}
