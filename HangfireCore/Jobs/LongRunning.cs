using System;
using System.Threading;

namespace HangfireCore.Jobs
{
    public class LongRunningArgs 
    {
        public int JobDuration;
        public int SleepDuration;
        public string TimeStamp;
    }

    public class LongRunning
    { 
        /// <summary>
        /// Starts the action
        /// </summary>
        public  void Start(LongRunningArgs args, CancellationToken cancellationToken)
        {

            try
            {
                // TODO: EL - can argumemnts be strongly typed somehow?
                var iterationCounter = 0;
                var timePast = 0;
                var jobDuration = args.JobDuration * 1000;
                var sleepDuration = args.SleepDuration * 1000;
                var totalIteration = jobDuration / sleepDuration;
                var timeStamp = args.TimeStamp;
                var startMsg = $"StartTime: {timeStamp}, WaitingTime {sleepDuration / 1000} seconds, total job duration {jobDuration / 1000} seconds.";

                System.Diagnostics.Debug.WriteLine(startMsg);

                while (timePast <= jobDuration)
                {
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        iterationCounter++;
                        var msg = $" current iteration: {iterationCounter}, time past: {timePast / 1000} seconds, total job duration {jobDuration / 1000} seconds.";
                        System.Diagnostics.Debug.WriteLine(msg);
                        Thread.Sleep(sleepDuration);
                        timePast = iterationCounter * sleepDuration;
                    }
                    else
                    {
                    System.Diagnostics.Debug.WriteLine("Long running cancelled");
                        break;
                    }

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                System.Diagnostics.Debug.WriteLine("finished");
            }
        }
    }
}
