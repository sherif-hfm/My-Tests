﻿using log4net;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quartz
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                //Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };

                // Grab the Scheduler instance from the Factory 
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

                // and start it off
                scheduler.Start();
                Logger.Log.Info("Scheduler Started");

                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<HelloJob>().WithIdentity("job1", "group1").Build();

                // Trigger the job to run now, and then repeat every 10 seconds
                //ITrigger trigger = TriggerBuilder.Create().WithIdentity("trigger1", "group1").StartNow().WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever()).Build();
                ITrigger trigger = TriggerBuilder.Create().WithIdentity("trigger1", "group1").WithCronSchedule("*/5 * * ? * *").Build();

                // Tell quartz to schedule the job using our trigger
                scheduler.ScheduleJob(job, trigger);

                // some sleep to show what's happening
                //Thread.Sleep(TimeSpan.FromSeconds(60));
                Console.ReadLine();

                // and last shut down the scheduler when you are ready to close your program
                scheduler.Shutdown();
                Console.ReadLine();
                Logger.Log.Info("Scheduler Shutdown");
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
    }
    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                //throw new Exception("Exception Test");
                //Logger.Log.Info("HelloJob Execute");
                Console.WriteLine("Greetings from HelloJob ! " + DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }
        }
    }

}
