using System.Threading;
using IsItUpLogic;
using Quartz;
using Quartz.Impl;
using Quartz.Core;
using Quartz.Listener;
using Quartz.Simpl;
using Quartz.Util;
using Quartz.Xml;
using System.Threading.Tasks;

namespace IsItUpService
{
    public class Service
    {
        public async Task Start()
        {
            var scheduler = await new StdSchedulerFactory().GetScheduler();
            await scheduler.Start();
            var job = JobBuilder.Create<MyJob>().Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("Up Checker Trigger")
                .WithSimpleSchedule(s => s.WithIntervalInSeconds(10).RepeatForever())
                .StartNow()
                .WithPriority(1)
                .Build();
            await scheduler.ScheduleJob(job, trigger);
        }

        public void Stop()
        {

        }
    }

    public class MyJob : IJob
    {
        private readonly IUpChecker _upChecker = new NotifyingUpChecker();

        public async Task Execute(IJobExecutionContext context)
        {
            await _upChecker.IsItUpAsync(System.Configuration.ConfigurationManager.AppSettings["UrlToCheck"]);
        }
    }
}
