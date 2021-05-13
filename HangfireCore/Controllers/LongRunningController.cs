using Hangfire;
using HangfireCore.Jobs;

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
    public class LongRunningController : ControllerBase
    {
        [HttpGet]
        [Route("RunLongRunningJob")]
        public IActionResult RunLongRunningJob()
        {
            var longRunning = new LongRunning();
            BackgroundJob.Enqueue(() => longRunning.Start(new LongRunningArgs { JobDuration = 3600, SleepDuration = 10, TimeStamp = DateTime.Now.ToString() }, CancellationToken.None));
            return Ok();
        }
    }
}
