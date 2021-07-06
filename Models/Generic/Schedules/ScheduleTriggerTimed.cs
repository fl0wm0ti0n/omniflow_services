using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Generic.Schedules
{
    public class ScheduleTriggerTimed : ScheduleTriggerBase
    {
        public int ScheduleTriggerEntityId { get; set; }
        public string Name { get; set; }
        public string Trigger { get; set; }
        public string Value { get; set; }
        public TimeSpan TimedIntervall { get; set; }
        public TimeSpan Intervall { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Endless { get; set; }
        public bool Once { get; set; }
        public bool Minutely { get; set; }
        public TimeSpan MinutelyTime { get; set; }
        public bool Hourly { get; set; }
        public DateTime HourlyTime { get; set; }
        public bool Daily { get; set; }
        public bool Weekly { get; set; }
        public bool Monthly { get; set; }
        public bool Yearly { get; set; }
        public DateTime LastTime { get; set; }
        public DateTime NextTime { get; set; }
        [Required]
        public ICollection<DayOfWeek> OnDays { get; set; }
    }
    public enum ScheduleDays
    {
        Montag = 1,
        Dienstag = 2,
        Mittwoch = 3,
        Donnerstag = 4,
        Freitag = 5,
        Samstag = 6,
        Sonntag = 7
    }
}
