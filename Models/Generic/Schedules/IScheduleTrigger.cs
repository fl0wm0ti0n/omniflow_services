using System;

namespace Models.Generic.Schedules
{
    public interface IScheduleTrigger
    {
        public int ScheduleTriggerEntityId { get; set; }
        public string Name { get; set; }
        public string Trigger { get; set; }
        public string Value { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime LastTime { get; set; }
        public DateTime NextTime { get; set; }
        public ScheduleTriggerTyp TriggerTyp { get; set; }
        public DateTime GetNextTime();
        public bool GetStatus();
    }
}