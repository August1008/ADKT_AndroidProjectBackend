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
    public class AttendencesController : ControllerBase
    {
        private AttendenceService attendenceService { set; get; }

        public AttendencesController(AttendenceService attendenceService)
        {
            this.attendenceService = attendenceService;
        }

        [HttpGet("get-attendence-by-lessionId")]
        public async Task<ActionResult>GetAttendenceByLessionId(int lessionId)
        {
            return Ok(attendenceService.GetAttendenceByLessionId(lessionId));
        }
    }
}
