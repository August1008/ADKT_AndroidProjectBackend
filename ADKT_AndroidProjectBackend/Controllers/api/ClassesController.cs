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
    public class ClassesController : ControllerBase
    {
        private ClassService classService { set; get; }

        public ClassesController(ClassService classService)
        {
            this.classService = classService;
        }

        [HttpGet("get-class-list")]
        public async Task<ActionResult> GetClassList()
        {
            return Ok(new { status = true, data = classService.GetClassList() });
        }
        [HttpGet("get-class-list-teacherid")]
        public async Task<ActionResult> GetClassListByTeacherId(string TeacherId)
        {
            return Ok(new { status = true, data = classService.GetClassByTeacherId(TeacherId) });
        }
        [HttpPost("add-new-class")]
        public async Task<ActionResult> AddNewClass(ClassInsertModel classModel)
        {
            Class newClass = new Class()
            {
                ClassId = classService.GenerateId(),
                startDate = classModel.startDate,
                endDate = classModel.endDate,
                Subject = classModel.Subject,
                TeacherId = classModel.TeacherId
            };
            classService.AddClass(newClass);
            return Ok(new { status = true, message = "successfully" });
        }
        [HttpDelete("delete-class")]
        public async Task<ActionResult> DeleteClass(string ClassId)
        {
            classService.DeleteClass(ClassId);
            return Ok(new { status = true, message = "" });
        }
    }
}
