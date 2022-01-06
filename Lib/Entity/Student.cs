using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Lib.Entity
{
    public class Student
    {
        [Key]
        [StringLength(10)]
        public string StudentId { set; get; }
        [StringLength(50)]
        public string Name { set; get; }
        public DateTime birthDay { set; get; }
        [StringLength(50)]
        public string Email { set; get; }

        [ForeignKey("ApplicationUser")]
        public Guid UserId { set; get; }
        public ApplicationUser User { set; get; }
        public Guid PersonId { set; get; }

        public ICollection<Enrollment> Enrollments { set; get; }
    }
}
