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
    public class EnrollmentsController : ControllerBase
    {
        private EnrollmentService enrollmentService { set; get; }

        public EnrollmentsController(EnrollmentService enrollmentService)
        {
            this.enrollmentService = enrollmentService;
        }
        [HttpGet("get-enrollment-list")]
        public async Task<ActionResult> GetEnrollmentList()
        {
            return Ok();
        }

        [HttpGet("get-enrollments")]
        public async Task<ActionResult> GetEnrollmentsBystudentId(string studentId)
        {
            return Ok(enrollmentService.GetEnrollmentsBystudentId(studentId));
        }
    }
}
