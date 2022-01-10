using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class StudentModel 
    {
        public string StudentId { set; get; }
        public string Name { set; get; }
        public DateTime birthDay { set; get; }
        public string Email { set; get; }
        public Guid UserId { set; get; }
        public Guid PersonId { set; get; }
        //public List<Enrollment> enrollments { set; get; }
    }
}
