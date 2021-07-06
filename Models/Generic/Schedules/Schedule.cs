using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Models.Generic.Schedules
{
    class Schedule : ISchedule
    {
        private volatile bool isPaused;
        private volatile bool isStopped;
        private Task _BackgroundTask;

        public int SchedulesEntityId { get; set; }
        public string Name { get; set; }
        public ScheduleTyp ScheduleTyp { get; set; }
        public TimeSpan TimedIntervall { get; set; }
        public TimeSpan Intervall { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime LastTime { get; set; }
        public DateTime NextTime { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
        public bool PushMessage { get; set; }
        public bool LogMessage { get; set; }
        public bool SaveResult { get; set; }
        public bool OverrideResult { get; set; }
        public string Creator { get; set; }
        public ICollection<string> SharedToUsers { get; set; }
        public ICollection<ScheduleDays> OnDays { get; set; }
        public ICollection<IScheduleTask> ScheduleTasks { get; set; }
        public ICollection<IScheduleTrigger> ScheduleTriggers { get; set; }

        public async Task<bool> Run()
        {
            _BackgroundTask = new Task(() =>
            {
                while (!isStopped)
                {
                    while (!isPaused && !isStopped)
                    {
                        // pruefe bedingungen (trigger)
                        Thread.Sleep(100); // set some delay before check if task is set on pause
                    }

                    Thread.Sleep(100); // set some timeout before check if task is stopped              }
                }
            });
            return true;
        }

        public async Task<bool> Stop()
        {
            isPaused = true;
            isStopped = true;
            return true;
        }
        public async Task<bool> Resume()
        {
            isPaused = false;
            return true;
        }
        public async Task<bool> Pause()
        {
            isPaused = true;
            return true;
        }
        public async Task<bool> Kill()
        {
            return true;
        }
        public async Task<bool> GetTaskResults()
        {
            return true;
        }
        public async Task<bool> SaveTaskResults()
        {
            return true;
        }
        public async Task<bool> Update()
        {
            return true;
        }
        public DateTime GetNextTime()
        {
            return DateTime.Now;
        }
        public bool GetStatus()
        {
            return true;
        }
    }
}
