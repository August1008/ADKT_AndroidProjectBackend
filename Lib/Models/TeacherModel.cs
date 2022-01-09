using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class TeacherModel
    {
        public string TeacherId { set; get; }
        public string Name { set; get; }
        public Guid UserId { set; get; }
    }
}
