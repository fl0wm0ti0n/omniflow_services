using System;

namespace Models.Generic.Schedules
{
    public class ScheduleTriggerBase : IScheduleTrigger
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

        public DateTime GetNextTime()
        {
            return DateTime.Now;
        }

        public bool GetStatus()
        {
            return true;
        }
    }

    public enum ScheduleTriggerTyp
    {
        GotData = 1,
        GotMessage = 2,
        ShutOffEvent = 3,
        ShutOnEvent = 4,
        TimedEvent = 5,
        LogEvent = 6
    }
}