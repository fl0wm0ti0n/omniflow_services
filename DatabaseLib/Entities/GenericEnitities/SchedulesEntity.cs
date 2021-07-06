#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using DatabaseLib.Entities.NodeMonEntities;

namespace DatabaseLib.Entities.GenericEntities
{
    [Table("generic_Schedules")]
    public class SchedulesEntity
    {
        [Key]
        [Required]
        public int SchedulesEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ScheduleTypEntityId { get; set; }
        [Required]
        public ScheduleTypEntity ScheduleTypEntity { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public DateTime LastTime { get; set; }
        public DateTime NextTime { get; set; }
        public string Value { get; set; }
        public bool Active { get; set; }
        public bool PushMessage { get; set; }
        public bool LogMessage { get; set; }
        public bool SaveResult { get; set; }
        public bool OverrideResult { get; set; }
        public int? UserEntityId { get; set; }
        public UserEntity Creator { get; set; }
        public ICollection<SchedulesToUsersEntity> SchedulesToUsersEntity { get; set; }
        public ICollection<ScheduleTaskEntity> ScheduleTasksEntity { get; set; }
        public ICollection<ScheduleTriggerEntity> ScheduleTriggerEntity { get; set; }
    }

    [Table("generic_ScheduleToUsers")]
    public class SchedulesToUsersEntity
    {
        [Key]
        [Required]
        public int SchedulesToUsersEntityId { get; set; }
        public int? SchedulesEntityId { get; set; }
        public SchedulesEntity? SchedulesEntity { get; set; }
        public int? UserEntityId { get; set; }
        public UserEntity? UserEntity { get; set; }
    }

    [Table("generic_ScheduleTypes")]
    public class ScheduleTypEntity
    {
        [Key]
        [Required]
        public int ScheduleTypEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<SchedulesEntity> SchedulesEntity { get; set; }
    }

    [Table("generic_ScheduleDays")]
    public class ScheduleDaysEntity
    {
        [Key]
        [Required]
        public int ScheduleDaysEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<SchedulesToDaysEntity> SchedulesToDaysEntity { get; set; }
    }

    [Table("generic_SchedulesToDays")]
    public class SchedulesToDaysEntity
    {
        [Key]
        [Required]
        public int SchedulesToDaysEntityId { get; set; }
        public int? ScheduleTriggerEntityId { get; set; }
        public ScheduleTriggerEntity? ScheduleTriggerEntity { get; set; }
        public int? ScheduleDaysEntityId { get; set; }
        public ScheduleDaysEntity? ScheduleDaysEntity { get; set; }
    }

    [Table("generic_ScheduleTasks")]
    public class ScheduleTaskEntity
    {
        [Key]
        [Required]
        public int ScheduleTaskEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Task { get; set; }
        public string Value { get; set; }
        public DateTime LastTime { get; set; }
        public bool LastRunOk { get; set; }
        public string LastState { get; set; }
        public int retry { get; set; }
        [Column(TypeName = "bigint")]
        public TimeSpan Duration{ get; set; }
        [Required]
        public int ScheduleTaskTypEntityId { get; set; }
        [Required]
        public ScheduleTaskTypEntity ScheduleTaskTypEntity { get; set; }
    }

    [Table("generic_ScheduleTaskTypes")]
    public class ScheduleTaskTypEntity
    {
        [Key]
        [Required]
        public int ScheduleTaskTypEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ScheduleTaskEntity> ScheduleTaskEntity { get; set; }
    }

    [Table("generic_ScheduleTriggers")]
    public class ScheduleTriggerEntity
    {
        [Key]
        [Required]
        public int ScheduleTriggerEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Trigger { get; set; }
        public string Value { get; set; }
        [Column(TypeName = "bigint")]
        public TimeSpan TimedIntervall { get; set; }
        [Column(TypeName = "bigint")]
        public TimeSpan Intervall { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public bool Endless { get; set; }
        public bool Once { get; set; }
        public bool Minutely { get; set; }
        [Column(TypeName = "bigint")]
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
        public int ScheduleTriggerTypEntityId { get; set; }
        [Required]
        public ScheduleTriggerTypEntity ScheduleTriggerTypEntity { get; set; }
        public ICollection<SchedulesToDaysEntity> SchedulesToDaysEntity { get; set; }
    }

    [Table("generic_ScheduleTriggerTypes")]
    public class ScheduleTriggerTypEntity
    {
        [Key]
        [Required]
        public int ScheduleTriggerTypEntityId { get; set; }
        [Required]
        public string Name { get; set; }
        public ScheduleTriggerEntity ScheduleTriggerEntity { get; set; }
    }
}