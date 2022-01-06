using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADKT_AndroidProjectBackend.Models
{ 
    public class StudentInsertModel
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public int UserType { set; get; }
        public string StudentId { set; get; }

        public string Name { set; get; }
        public DateTime BirthDay { set; get; }
        public string Email { set; get; }

        public Guid UserId { set; get; }

        public List<byte[]> Images { set; get; }

    }
}
