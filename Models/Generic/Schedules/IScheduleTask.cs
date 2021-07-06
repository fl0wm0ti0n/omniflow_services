using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Generic.Schedules
{
    public interface IScheduleTask
    {
        public int ScheduleTaskEntityId { get; set; }
        public string Name { get; set; }
        public string ScheduleTaskTyp { get; set; }
        public string Task { get; set; }
        public string Value { get; set; }
        public DateTime LastTime { get; set; }
        public bool LastRunOk { get; set; }
        public string LastState { get; set; }
        public Task<bool> RunTask();
        public Task<bool> StopTask();
        public Task<bool> PauseTask();
        public Task<bool> KillTask();
        public Task<bool> GetTaskResult();
        public Task<bool> SaveTaskResult();
    }
}