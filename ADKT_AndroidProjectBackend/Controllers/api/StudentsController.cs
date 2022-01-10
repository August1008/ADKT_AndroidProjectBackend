
using Lib.Entity;
using Lib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ADKT_AndroidProjectBackend.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private StudentService studentService { set; get; }
        private EnrollmentService enrollmentService { set; get; }
        private FaceClient client { set; get; }
        private ApplicationUserService userService { set; get; }
        public StudentsController(StudentService studentService,ApplicationUserService userService, EnrollmentService enrollmentService)
        {
            this.enrollmentService = enrollmentService;
            this.studentService = studentService;
            this.userService = userService;
            client = new FaceClient(new ApiKeyServiceClientCredentials("d6c82c774f8543b0a67168492ac6dc4a"))
            {
                Endpoint = "https://binhan.cognitiveservices.azure.com/"
            };
        }

        [HttpGet("get-student-list")]
        public async Task<ActionResult> GetStudentList()
        {
            return Ok(new { status = true, data = studentService.GetStudentList() });
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteStudent(string Id)
        {
            studentService.DeleteStudent(Id);
            return Ok(new { status = true, message = "successfully" });
        }

        
        [HttpPost("create-student")]
        public async Task<ActionResult> CreateStudent(IFormCollection formdata)
        {
            var images = HttpContext.Request.Form.Files;

            var username = HttpContext.Request.Form["username"];
            var password = HttpContext.Request.Form["password"];
            var name = HttpContext.Request.Form["name"];
            var email = HttpContext.Request.Form["email"];
            var birthday = HttpContext.Request.Form["birthday"];
            var studentid = HttpContext.Request.Form["studentid"];

            // tao 1 person mới 
            Task<Person> CreatePersonTask = client.PersonGroupPerson.CreateAsync("adkt", studentid.ToString(), name.ToString());
            Person person = CreatePersonTask.Result;

            // them 1 tai khoan
            ApplicationUser newUser = new ApplicationUser()
            {
                UserId = new Guid(),
                Username = username,
                Password = password,
                UserType = 1
            };
            userService.AddUser(newUser);
            // them 1 student
            Student newStudent = new Student()
            {
                Name = name,
                birthDay = DateTime.ParseExact(birthday, "d/M/yyyy", CultureInfo.InvariantCulture),
                Email = email,
                StudentId = studentid,
                UserId = newUser.UserId,
                PersonId = person.PersonId,
            };
            studentService.AddStudent(newStudent);

            //List<Stream> imgList = new List<Stream>();
            
            //Verify faces in image list
            // train data by using microsoft api
            Stream tempStream = null;
            foreach (var img in images)
            {
                tempStream = img.OpenReadStream();
                await client.PersonGroupPerson.AddFaceFromStreamAsync("adkt", person.PersonId, tempStream);
            }
            //Train data
            await TrainGroup(client);
            return Ok(new { status = true, message = "Successfully" });
        }

        [HttpPost("enroll")]
        public async Task<ActionResult> EnrollClass(string classId,string studentId)
        {
            Enrollment enrollment = new Enrollment
            {
                //EnrollmentId = (new Random().Next()),
                ClassId = classId,
                StudentId = studentId
            };
            enrollmentService.AddEnrollment(enrollment);
            return Ok(new { status = true, message = "successfully" });
        }

        public async Task TrainGroup(FaceClient client)
        {
            await client.PersonGroup.TrainAsync("adkt");
            //while (true)
            //{
            //    await Task.Delay(1000);
            //    var trainingStatus = await client.PersonGroup.GetTrainingStatusAsync("adkt");
            //    Console.WriteLine($"Training status: {trainingStatus.Status}.");
            //    if (trainingStatus.Status == TrainingStatusType.Succeeded) { break; }
            //}
        }
    }
}
