using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Models
{
    public class UserModel
    {
        public const int STUDENT = 1;
        public const int TEACHER = 2;
        public string Username { set; get; }
        public string Password { set; get; }
        public int UserType { set; get; }
    }
}
