using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DatabaseLib.Entities.GenericEntities;
using Models.Generic.Schedules;

namespace NodeMonitor.Services
{

    public sealed class ScheduleService
    {
        private List<ISchedule> Schedules;
        private List<ScheduleTaskEntity> ScheduleTaskEntities;

        public ScheduleService()
        {

        }

        public void UpdateScheduleList(SchedulesEntity newSchedule)
        {

        }

        public void RunSchedules()
        {

        }

        public void StopSchedules()
        {

        }
    }
}
