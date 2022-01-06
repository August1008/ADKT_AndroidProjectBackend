using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lib.Entity
{
    public class ApplicationUser
    {
        [Key]
        public Guid UserId { set; get; }
        [StringLength(30)]
        public string Username { set; get; }
        [StringLength(100)]
        public string Password { set; get; }
        public int UserType { set; get; }

    }
}
