using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTimerPattern
{
    class Program
    {
        static ILogger logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

        static async Task Main(string[] args)
        {
            // One second timer period
            TimeSpan timerPeriod = new TimeSpan(0, 0, 1);

            var cancellationTokenSource = new CancellationTokenSource();

            var taskTimer = new TaskTimer(() => Process(), 
                timerPeriod, 
                logger,
                cancellationTokenSource);
            
            // start the timer
            taskTimer.Start();

            // hold the main thread from exiting.
            Console.ReadLine();
            cancellationTokenSource.Cancel();
            Console.WriteLine("Canceled.");

            // let it drain
            await Task.Delay(timerPeriod);
        }

        private static void Process()
        {
            int i = 0;
            if (i > 0)
                throw new Exception();
            logger.Information($"Time is {DateTime.Now.ToString("hh:mm:ss.fff")}. Processing..");
            Thread.Sleep(20);
        }
    }
}
