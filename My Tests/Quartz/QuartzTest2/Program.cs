using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<HelloJob>().Build();
            ITrigger trigger = TriggerBuilder.Create().WithIdentity("trigger1").WithCronSchedule("*/5 * * ? * *").Build();
            scheduler.ScheduleJob(job, trigger);
            
            Console.ReadLine();
            scheduler.Shutdown();
            Console.ReadLine();
        }
    }

    [DisallowConcurrentExecution]
    public class HelloJob : IJob
    {
        private DateTime startDate = DateTime.Now;

        public HelloJob()
        {
            Console.WriteLine("Constractor " + DateTime.Now.ToString());
        }

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                //context.Scheduler.PauseJob(context.JobDetail.Key);
                //Console.WriteLine("Greetings from HelloJob ! " + DateTime.Now.ToString());
                Console.WriteLine("Job Start ! " + DateTime.Now.ToString());
                Thread.Sleep(new TimeSpan(0, 0, 10));
                Console.WriteLine("Job End ! " + DateTime.Now.ToString());
                //context.Scheduler.ResumeJob(context.JobDetail.Key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
