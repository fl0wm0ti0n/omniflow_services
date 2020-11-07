using DatabaseLib.Entities;
using NodeMonitor.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

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
                        Uri = "https://explorer.grid.tf/explorer/farms/173599"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "Farm-1",
                        Typ = "Farms",
                        List = false,
                        Uri = "https://explorer.grid.tf/explorer/farms/1"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "omniflowNode-6epBaRjPkLrb3ViYqi2JxTx6ALbNNeYysTuw5MskwWkX",
                        Typ = "Nodes",
                        List = false,
                        Uri = "https://explorer.grid.tf/explorer/nodes/6epBaRjPkLrb3ViYqi2JxTx6ALbNNeYysTuw5MskwWkX"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "omniflowNode-Assy3QYdGxBfubySThkkmkx9nnXYogmkujWTFyesqoQf",
                        Typ = "Nodes",
                        List = false,
                        Uri = "https://explorer.grid.tf/explorer/nodes/Assy3QYdGxBfubySThkkmkx9nnXYogmkujWTFyesqoQf"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "omniflowNode-7fpLSJBfRL31RXjSxXKTz4zAfVnZdEmAJW3cfRepzFyx",
                        Typ = "Nodes",
                        List = false,
                        Uri = "https://explorer.grid.tf/explorer/nodes/7fpLSJBfRL31RXjSxXKTz4zAfVnZdEmAJW3cfRepzFyx"
                    },
                    new ThreefoldApiUriEntity()
                    {
                        Name = "omniflowNode-8WZRD4ToUuCVYgh46uujwXcnZw9ZXTz1Z6SAKJHzhsJY",
                        Typ = "Nodes",
                        List = false,
                        Uri = "https://explorer.grid.tf/explorer/nodes/8WZRD4ToUuCVYgh46uujwXcnZw9ZXTz1Z6SAKJHzhsJY"
                    }
                };
                return modifiedUris;
            }
        }
    }
}