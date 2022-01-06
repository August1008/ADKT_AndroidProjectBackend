using ADKT_AndroidProjectBackend.Models;
using Lib.Entity;
using Lib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADKT_AndroidProjectBackend.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ApplicationUserService service;
        private StudentService studentService;
        private TeacherService teacherService;


        public UsersController(ApplicationUserService service, StudentService studentService, TeacherService teacherService)
        {
            this.service = service;
            this.studentService = studentService;
            this.teacherService = teacherService;
        }

        [HttpGet("get-all-users")]
        public ActionResult GetAllUser()
        {
            return Ok(new { status = true, data = service.GetApplicationUserList() });
        }

        [HttpGet("login")]
        public ActionResult Login(UserModel user)
        {
            ApplicationUser loginUser = service.Login(user.Username, user.Password);
            if (loginUser == null)
                return Ok();
            if (user.UserType == UserModel.STUDENT)
            {
                Student student = studentService.GetStudentByUserId(loginUser.UserId);
                return Ok(student);
            }
            else
            {
                Teacher teacher = teacherService.GetTeacherByUserId(loginUser.UserId);
                return Ok(teacher);
            }
        }

        [HttpPost("create-user")]
        public ActionResult CreateUser(UserModel user)
        {
            ApplicationUser newUser = new ApplicationUser()
            {
                UserId = new Guid(),
                Username = user.Username,
                Password = user.Password,
                UserType = user.UserType
            };
            service.AddUser(newUser);
            return Ok(new { status = true, message = "" });
        }
    }
}
