using System.Collections.Generic;

namespace DataTransferObjects.NodeMon
{
    public class NodeMonSchedulesDto
    {
        public int NodeMonSchedulesEntityId { get; set; }
        public string Name { get; set; }
        public string ScheduleTyp { get; set; }
        public long TimedIntervall { get; set; }
        public long Intervall { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Value { get; set; }
        public ICollection<NodeMonSchedulesToDaysDto> SchedulesToDays{ get; set; }
    }

    public class NodeMonScheduleDaysDto
    {
        public int NodeMonScheduleDaysEntityId { get; set; }
        public string Name { get; set; }
        public string DayTypNr { get; set; }
        public ICollection<NodeMonSchedulesToDaysDto> SchedulesToDays { get; set; }
    }

    public class NodeMonSchedulesToDaysDto
    {
        public int NodeMonSchedulesToDaysEntityId { get; set; }
        public int NodeMonSchedulesEntityId { get; set; }
        public int NodeMonScheduleDaysEntityId { get; set; }
    }
}