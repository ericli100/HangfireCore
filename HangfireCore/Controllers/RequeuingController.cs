using Hangfire;
using HangfireCore.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HangfireCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequeuingController : ControllerBase
    {
        [HttpGet]
        [Route("RunQueuing")]
        public IActionResult RunQueuing()
        {
            var requeuing = new Requeuing();
            BackgroundJob.Enqueue(() => requeuing.Start(CancellationToken.None));
            return Ok();
        }
    }
}
