using System;
using System.Collections.Generic;

namespace DataTransferObjects.Models.NodeMon
{
    public class SchedulesDto
    {
        public int SchedulesDtoId { get; set; }
        public string Name { get; set; }
        public ScheduleTypEnity ScheduleTypDto { get; set; }
        public TimeSpan TimedIntervall { get; set; }
        public TimeSpan Intervall { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime LastTime { get; set; }
        public DateTime NextTime { get; set; }
        public string Value { get; set; }
        public UserDto Creator { get; set; }
        public ICollection<UserDto> ShareToUsers { get; set; }
        public ICollection<SchedulesToDaysDto> SchedulesToDaysDto { get; set; }
        public ICollection<ScheduleTaskDto> ScheduleTasksDto { get; set; }
        public ICollection<ScheduleTriggerDto> ScheduleTriggerDto { get; set; }
    }

    public class ScheduleTypEnity
    {
        public int ScheduleDaysDtoId { get; set; }
        public string Name { get; set; }
    }

    public class ScheduleDaysDto
    {
        public int ScheduleDaysDtoId { get; set; }
        public string Name { get; set; }
        public ICollection<SchedulesToDaysDto> SchedulesToDaysDto { get; set; }
    }

    public class SchedulesToDaysDto
    {
        public int SchedulesToDaysDtoId { get; set; }
        public int SchedulesDtoId { get; set; }
        public SchedulesDto SchedulesDto { get; set; }
        public int ScheduleDaysDtoId { get; set; }
        public ScheduleDaysDto ScheduleDaysDto { get; set; }
    }

    public class ScheduleTaskDto
    {
        public int ScheduleTaskDtoId { get; set; }
        public string Name { get; set; }
        public ScheduleTaskTypDto ScheduleTaskTypDto { get; set; }
        public string Task { get; set; }
    }

    public class ScheduleTaskTypDto
    {
        public int ScheduleTaskTypDtoId { get; set; }
        public string Name { get; set; }
    }

    public class ScheduleTriggerDto
    {
        public int ScheduleTriggerDtoId { get; set; }
        public string Name { get; set; }
        public ScheduleTriggerTypDto ScheduleTriggerTypDto { get; set; }
        public string Trigger { get; set; }
        public string Value { get; set; }
    }

    public class ScheduleTriggerTypDto
    {
        public int ScheduleTriggerTypDtoId { get; set; }
        public string Name { get; set; }
    }
}