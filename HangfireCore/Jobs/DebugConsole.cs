using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangfireCore.Jobs
{

    public class DebugConsole 
    {
        public  void ConsoleLog(string content, CancellationToken cancellationToken)
        {
            Thread.Sleep(100);
        }
    }
}

