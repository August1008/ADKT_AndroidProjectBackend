using Lib.Models;
using Lib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ADKT_AndroidProjectBackend.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private IFaceClient client { set; get; }
        private ClassService classService { set; get; }
        private StudentService studentService { set; get; }

        public TeachersController(ClassService classService, StudentService studentService)
        {
            this.client = new FaceClient(new ApiKeyServiceClientCredentials("d6c82c774f8543b0a67168492ac6dc4a"))
            {
                Endpoint = "https://binhan.cognitiveservices.azure.com/"
            };
            this.classService = classService;
            this.studentService = studentService;
        }

        [HttpPost("class-attendance")]
        public async Task<ActionResult> ClassAttendance(IFormCollection dataFrom)
        {
            // lay hinh chup lop 
            var images = HttpContext.Request.Form.Files;
            Stream classImage = images[0].OpenReadStream();

            // xac dinh khuon mat ca lop
            //Task<IList<DetectedFace>> DetectFaceTask = client.Face.DetectWithStreamAsync(classImage);
            IList<DetectedFace> detectedFaces = await client.Face.DetectWithStreamAsync(classImage,
                recognitionModel:RecognitionModel.Recognition04,
                detectionModel: DetectionModel.Detection03);
            
            // lay danh sach cac khuon mat dua vao sourceFaceIds
            IList<Guid> sourceFaceIds = new List<Guid>();
            foreach(var face in detectedFaces)
            {
                sourceFaceIds.Add(face.FaceId.Value);
            }

            // nhan dien cac khuon mat trong gourp person
            IList<IdentifyResult> identifyResults = null;
            //Task<IList<IdentifyResult>> identifyResultTask = client.Face.IdentifyAsync(sourceFaceIds, "adkt");
            try
            {
                identifyResults = await client.Face.IdentifyAsync(sourceFaceIds, "adkt");
            }catch(Microsoft.Azure.CognitiveServices.Vision.Face.Models.APIErrorException ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            // lay ra danh sach student co trong hinh
            List<StudentModel> studentList = new List<StudentModel>();
            Person person = null;
            foreach(var result in identifyResults)
            {
                person = client.PersonGroupPerson.GetAsync("adkt", result.Candidates[0].PersonId).Result;
                studentList.Add(studentService.GetStudentByPersonId(person.PersonId));
            }

            return Ok(studentList);
        }

    }
}
