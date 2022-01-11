using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Models
{
    public class AttendenceModel
    {
        public string StudentId { get; set; }
        public int LessionId { get; set; }
        public string StudentName { get; set; }
        public string ClassId { get; set; }
        public bool Status { get; set; }
    }
}
