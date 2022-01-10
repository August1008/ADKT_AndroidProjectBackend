using Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class EnrollmentModel
    {
        public string classId { set; get; }
        public string subject { set; get; }
        public string startDate { set; get; }
        public string endDate { set; get; }
        public string teacherName { set; get; }
        public string studentName { set; get; }
        public string studentId { set; get; }
    }
}
