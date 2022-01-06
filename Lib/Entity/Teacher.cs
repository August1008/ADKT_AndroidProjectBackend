using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lib.Entity
{
    public class Teacher
    {
        [Key]
        public string TeacherId { set; get; }
        [StringLength(50)]
        public string Name { set; get; }

        [ForeignKey("ApplicationUser")]
        public Guid UserId { set; get; }
        public ApplicationUser User { set; get; }

        public ICollection<Class> Classes { set; get; }
    }
}
