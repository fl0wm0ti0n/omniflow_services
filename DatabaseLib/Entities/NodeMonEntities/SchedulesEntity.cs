using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLib.Entities
{
    [Table("nodemon_Schedules")]
    public class NodeMonSchedulesEntity
    {
        [Key]
        [Required]
        public int NodeMonSchedulesEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ScheduleTyp { get; set; }
        [Required]
        public long TimedIntervall { get; set; }
        [Required]
        public long Intervall { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        [Required]
        public string Value { get; set; }
        public ICollection<NodeMonSchedulesToDaysEntity> SchedulesToDays{ get; set; }
    }

    [Table("nodemon_ScheduleDays")]
    public class NodeMonScheduleDaysEntity
    {
        [Key]
        [Required]
        public int NodeMonScheduleDaysEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DayTypNr { get; set; }
        public ICollection<NodeMonSchedulesToDaysEntity> SchedulesToDays { get; set; }
    }

    [Table("nodemon_SchedulesToDays")]
    public class NodeMonSchedulesToDaysEntity
    {
        [Key]
        [Required]
        public int NodeMonSchedulesToDaysEntityId { get; set; }
        public int NodeMonSchedulesEntityId { get; set; }
        public NodeMonSchedulesEntity NodeMonSchedulesEntity { get; set; }
        public int NodeMonScheduleDaysEntityId { get; set; }
        public NodeMonScheduleDaysEntity NodeMonScheduleDaysEntity { get; set; }
    }
}