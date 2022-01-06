using ADKT_AndroidProjectBackend.Models;
using Lib.Entity;
using Lib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
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
        private FaceClient client { set; get; }

        public StudentsController(StudentService studentService)
        {
            this.studentService = studentService;
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

        [HttpPost("create-student")]
        public async Task<ActionResult> CreateStudent(StudentInsertModel student)
        {
            // create new person in PersonGroup
            Task<Person> CreatePersonTask = client.PersonGroupPerson.CreateAsync("test", student.StudentId, student.Name);
            Person person = CreatePersonTask.Result;

            // Verify faces in image list 
            // train data by using microsoft api
            foreach (var img in student.Images)
            {
                // create a stream for every image
                MemoryStream stream = new MemoryStream(img);
                await client.PersonGroupPerson.AddFaceFromStreamAsync("test", person.PersonId, stream);
            }
            //Train data
            await TrainGroup(client);

            ApplicationUser newUser = new ApplicationUser()
            {
                UserId = new Guid(),
                Username = student.Username,
                Password = student.Password,
                UserType = student.UserType
            };
            Student newStudent = new Student()
            {
                Name = student.Name,
                birthDay = student.BirthDay,
                Email = student.Email,
                StudentId = student.StudentId,
                UserId = newUser.UserId,
                PersonId = person.PersonId,
            };
            studentService.AddStudent(newStudent);
            return Ok(new { status = true, message = "" });
        }
        public async Task TrainGroup(FaceClient client)
        {
            await client.PersonGroup.TrainAsync("test");
            while (true)
            {
                await Task.Delay(1000);
                var trainingStatus = await client.PersonGroup.GetTrainingStatusAsync("test");
                Console.WriteLine($"Training status: {trainingStatus.Status}.");
                if (trainingStatus.Status == TrainingStatusType.Succeeded) { break; }
            }
        }
    }
}
