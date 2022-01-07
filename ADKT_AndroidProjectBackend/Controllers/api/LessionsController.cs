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
    public class LessionsController : ControllerBase
    {
        LessionService lessionService { set; get; }

        public LessionsController(LessionService lessionService)
        {
            this.lessionService = lessionService;
        }

        [HttpGet("get-lession-by-classid")]
        public async Task<ActionResult> GetLessionByClassId(string classId)
        {
            //List<Lession> lsList = lessionService.GetLessionByClassId(classId);
            return Ok(new { status = true, data = lessionService.GetLessionByClassId(classId) });
        }
    }
}
