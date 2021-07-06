using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Generic.Schedules
{
    public interface ISchedule
    {
        public int SchedulesEntityId { get; set; }
        public string Name { get; set; }
        public ScheduleTyp ScheduleTyp { get; set; }
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
        public ICollection<IScheduleTask> ScheduleTasks { get; set; }
        public ICollection<IScheduleTrigger> ScheduleTriggers { get; set; }
        public Task<bool> Run();
        public Task<bool> Stop();
        public Task<bool> Pause();
        public Task<bool> Resume();
        public Task<bool> Kill();
        public Task<bool> GetTaskResults();
        public Task<bool> SaveTaskResults();
        public Task<bool> Update();
        public DateTime GetNextTime();
        public bool GetStatus();
    }

    public enum ScheduleTyp
    {
        Threefold = 1,
        CryptoBot = 2,
        Generic = 3
    }
}