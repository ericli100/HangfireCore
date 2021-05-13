using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HangfireCore.Jobs
{
    public class Requeuing
    {
        public void Start(CancellationToken cancellationToken)
        {
            var numberOfSubTasks = 1000;
            var debugConsole = new DebugConsole();
            try
            {
                for (int i = 0; i < numberOfSubTasks; i++)
                {
                    BackgroundJob.Enqueue(() => debugConsole.ConsoleLog($"Processing item {i}", CancellationToken.None));
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
           
        }
    }
}
