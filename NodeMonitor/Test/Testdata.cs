using NodeMonitor.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseLib.Entities.GenericEntities;
using DatabaseLib.Entities.NodeMonEntities;

namespace NodeMonitor.Test
{
    public static class Testdata
    {
        public static bool CreateTestdata()
        {
            try
            {
                Log.Information("create Testdata ...");
                using (var context = new nmDBContext())
                {
                    //newUris.ForEach(n => context.ThreefoldApiUris.Add(n));
                    foreach (var item in UriTestdata())
                    {
                        if (!context.ThreefoldApiUris.Any(f => f.Uri == item.Uri) || (!context.ThreefoldApiUris.Any()))
                        {
                            context.Update(item);
                            context.SaveChanges();
                        }
                        else
                        {
                            Log.Warning("Testdata " + item.Name + " from category 'Uri' is already saved in Database");
                        };
                    }
                }
                Log.Information("... success");
                return true;
            }
            catch (Exception e)
            {
                Log.Warning("Something went wrong by creating Testdata", e);
                return false;
            }
        }

        public static bool DeleteTestdata()
        {
            try
            {
                Log.Information("delete Testdata ...");
                using (var context = new nmDBContext())
                {
                    foreach (var item in UriTestdata())
                    {
                        if (context.ThreefoldApiUris.Any(f => f.Uri == item.Uri) || (context.ThreefoldApiUris.Any()))
                        {
                            context.Remove(item);
                            context.SaveChanges();
                        }
                        else
                        {
                            Log.Warning("Testdata " + item.Name + " from category 'Uri' is not found it Database");
                        };
                    }
                }
                Log.Information("... success");
                return true;
            }
            catch (Exception e)
            {
                Log.Warning("Something went wrong by deleting Testdata", e);
                return false;
            }
        }

        public static List<ThreefoldApiUriEntity> UriTestdata()
        {
            using (var context = new nmDBContext())
            {
                List<ThreefoldApiUriEntity> modifiedUris = new List<ThreefoldApiUriEntity>()
                {
                    new ThreefoldApiUriEntity()
                    {
                        Name = "omniflowFarm-173599",
                        Typ = "Farms",
                        List = false,
                        Uri = "173599"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "Farm-1",
                        Typ = "Farms",
                        List = false,
                        Uri = "1"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "omniflowNode-6epBaRjPkLrb3ViYqi2JxTx6ALbNNeYysTuw5MskwWkX",
                        Typ = "Nodes",
                        List = false,
                        Uri = "6epBaRjPkLrb3ViYqi2JxTx6ALbNNeYysTuw5MskwWkX"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "omniflowNode-Assy3QYdGxBfubySThkkmkx9nnXYogmkujWTFyesqoQf",
                        Typ = "Nodes",
                        List = false,
                        Uri = "Assy3QYdGxBfubySThkkmkx9nnXYogmkujWTFyesqoQf"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "omniflowNode-7fpLSJBfRL31RXjSxXKTz4zAfVnZdEmAJW3cfRepzFyx",
                        Typ = "Nodes",
                        List = false,
                        Uri = "7fpLSJBfRL31RXjSxXKTz4zAfVnZdEmAJW3cfRepzFyx"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "omniflowNode-8WZRD4ToUuCVYgh46uujwXcnZw9ZXTz1Z6SAKJHzhsJY",
                        Typ = "Nodes",
                        List = false,
                        Uri = "8WZRD4ToUuCVYgh46uujwXcnZw9ZXTz1Z6SAKJHzhsJY"
                    }
                };
                return modifiedUris;
            }
        }

        public static List<SchedulesEntity> SchedulesTestdata()
        {
            using (var context = new nmDBContext())
            {

                List<SchedulesEntity> modifiedSchedules = new List<SchedulesEntity>()
                {
                    new SchedulesEntity()
                    {
                        Name = "schedule_every5minutes_farms",
                        EndTime = new DateTime(2031, 12, 31, 23, 59, 59),
                        LastTime = new DateTime(2031, 12, 31, 23, 59, 59),
                        Intervall = new TimeSpan(0,5,50),
                        NextTime = new DateTime(),
                        StartTime = new DateTime(2021, 5, 30, 11, 59, 59),
                        TimedIntervall = new TimeSpan(0,5,50),
                        Value = "empty",
                        ScheduleTypEntity = context.ScheduleTypes.Find(1),
                        Creator =  context.Users.SingleOrDefault(u => u.Name == "admin"),
                    },
                    new SchedulesEntity()
                    {
                        Name = "schedule_every5minutes_nodes",
                        EndTime = new DateTime(2031, 12, 31, 23, 59, 59),
                        LastTime = new DateTime(2031, 12, 31, 23, 59, 59),
                        Intervall = new TimeSpan(0,5,50),
                        NextTime = new DateTime(),
                        StartTime = new DateTime(2021, 5, 30, 11, 59, 59),
                        TimedIntervall = new TimeSpan(0,5,50),
                        Value = "empty",
                        ScheduleTypEntity = context.ScheduleTypes.Find(1),
                        Creator =  context.Users.SingleOrDefault(u => u.Name == "admin"),
                    },
                    new SchedulesEntity()
                    {
                        Name = "schedule_every5minutes_mynode",
                    },
                };

                foreach (var exemplar in modifiedSchedules)
                {
                    exemplar.SchedulesToDaysEntity = new List<SchedulesToDaysEntity>
                    {
                        new SchedulesToDaysEntity {
                            SchedulesEntity = exemplar,
                            ScheduleDaysEntity = context.ScheduleDays.SingleOrDefault(d => d.Name == "Montag")
                        },
                        new SchedulesToDaysEntity {
                            SchedulesEntity = exemplar,
                            ScheduleDaysEntity = context.ScheduleDays.SingleOrDefault(d => d.Name == "Dienstag")
                        },
                        new SchedulesToDaysEntity {
                            SchedulesEntity = exemplar,
                            ScheduleDaysEntity = context.ScheduleDays.SingleOrDefault(d => d.Name == "Mittwoch")
                        },
                        new SchedulesToDaysEntity {
                            SchedulesEntity = exemplar,
                            ScheduleDaysEntity = context.ScheduleDays.SingleOrDefault(d => d.Name == "Donnerstag")
                        },
                        new SchedulesToDaysEntity {
                            SchedulesEntity = exemplar,
                            ScheduleDaysEntity = context.ScheduleDays.SingleOrDefault(d => d.Name == "Freitag")
                        },
                        new SchedulesToDaysEntity {
                            SchedulesEntity = exemplar,
                            ScheduleDaysEntity = context.ScheduleDays.SingleOrDefault(d => d.Name == "Samstag")
                        },                       
                        new SchedulesToDaysEntity {
                            SchedulesEntity = exemplar,
                            ScheduleDaysEntity = context.ScheduleDays.SingleOrDefault(d => d.Name == "Sonntag")
                        }
                    };

                }
                return modifiedSchedules;
            }
        }
    }
}