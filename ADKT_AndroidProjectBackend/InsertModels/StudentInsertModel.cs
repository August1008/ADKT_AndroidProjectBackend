using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace ADKT_AndroidProjectBackend.InsertModels
{ 
    public class StudentInsertModel
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public int UserType { set; get; }
        public string StudentId { set; get; }

        public string Name { set; get; }
        public string BirthDay { set; get; }
        public string Email { set; get; }

        public Guid UserId { set; get; }

        public FormCollection Images { set; get; }

    }
}
