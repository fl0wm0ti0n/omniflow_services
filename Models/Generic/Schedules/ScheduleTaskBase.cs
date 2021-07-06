using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Generic.Schedules
{
    public class ScheduleTaskBase : IScheduleTask
    {
        public int ScheduleTaskEntityId { get; set; }
        public string Name { get; set; }
        public string ScheduleTaskTyp { get; set; }
        public string Task { get; set; }
        public string Value { get; set; }
        public DateTime LastTime { get; set; }
        public bool LastRunOk { get; set; }
        public string LastState { get; set; }
        public int retry { get; set; }
        public TimeSpan Duration { get; set; }

        public async Task<bool> RunTask()
        {
            return false;
        }

        public async Task<bool> StopTask()
        {
            return false;
        }

        public async Task<bool> PauseTask()
        {
            return false;
        }

        public async Task<bool> KillTask()
        {
            return false;
        }

        public async Task<bool> GetTaskResult()
        {
            return false;
        }

        public async Task<bool> SaveTaskResult()
        {
            return false;
        }
    }
}
