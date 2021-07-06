using NodeMonitor.Models;
using DatabaseLib.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseLib.Entities.NodeMonEntities;

namespace NodeMonitor.Default
{
    public static class CreateDefaultTableValues
    {
        public static bool CreateData()
        {
            try
            {
                Log.Information("fill up Database with Defaultdata ...");
                using (var context = new nmDBContext())
                {
                    //newUris.ForEach(n => context.ThreefoldApiUris.Add(n));
                    foreach (var item in UriDefaultdata())
                    {
                        if (!context.ThreefoldApiUris.Any(f => f.Uri == item.Uri) || (!context.ThreefoldApiUris.Any()))
                        {
                            context.Update(item);
                            context.SaveChanges();
                        }
                        else
                        {
                            Log.Warning("Defaultdata " + item.Name + " from category 'Uri' is already saved in Database");
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

        public static bool DeleteData()
        {
            try
            {
                Log.Information("delete Defaultdata ...");
                using (var context = new nmDBContext())
                {
                    foreach (var item in UriDefaultdata())
                    {
                        if (context.ThreefoldApiUris.Any(f => f.Uri == item.Uri) || (context.ThreefoldApiUris.Any()))
                        {
                            context.Remove(item);
                            context.SaveChanges();
                        }
                        else
                        {
                            Log.Warning("Defaultdata " + item.Name + " from category 'Uri' is not found it Database");
                        };
                    }
                }
                Log.Information("... success");
                return true;
            }
            catch (Exception e)
            {
                Log.Warning("Something went wrong by deleting Defaultdata", e);
                return false;
            }
        }

        public static List<ThreefoldApiUriEntity> UriDefaultdata()
        {
            using (var context = new nmDBContext())
            {
                List<ThreefoldApiUriEntity> modifiedUris = new List<ThreefoldApiUriEntity>()
                {
                    new ThreefoldApiUriEntity()
                    {
                        Name = "AllNodes",
                        Typ = "nodes",
                        List = true,
                        Uri = "https://explorer.grid.tf/explorer/nodes"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "AllFarms",
                        Typ = "farms",
                        List = true,
                        Uri = "https://explorer.grid.tf/explorer/farms"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "AllReservations",
                        Typ = "reservations",
                        List = true,
                        Uri = "https://explorer.grid.tf/explorer/reservations"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "AllWorkloads",
                        Typ = "workloads",
                        List = true,
                        Uri = "https://explorer.grid.tf/explorer/workloads"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "AllUsers",
                        Typ = "users",
                        List = true,
                        Uri = "https://explorer.grid.tf/explorer/users"
                    }
                };
                return modifiedUris;
            }
        }
    }
}