using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using DatabaseLib.Entities;

namespace NodeMonitor.Test
{
    public static class Testdata
    {
        public static bool CreateTestdata()
        {
            try
            {
                using (var context = new nmDBContext())
                {
                   var newUris = UriTestdata();

                    foreach (var item in newUris)
                    {
                        if (item != null)
                        {
                            context.Update(item);
                            context.SaveChanges();
                            continue;
                        }
                        else
                        {
                            Log.Warning("no new Testdata");
                        }
                    }
                }
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
                using (var context = new nmDBContext())
                {
                    var oldUris = UriTestdata();
                    context.RemoveRange(oldUris);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Log.Warning("Something went wrong by deleting Testdata", e);
                return false;
            }
        }

        public static IList<ThreefoldApiUriEntity> UriTestdata()
        {
            try
            {
                IList<ThreefoldApiUriEntity> modifiedUris = null;

                using (var context = new nmDBContext())
                {

                    if (!context.ThreefoldApiUris.Any(f => f.Uri == "https://explorer.grid.tf/explorer/nodes/74cu7Tf2N6h1MfCYRVJTP5LTPjZZ5ZWsyfExd5CehRAM") || (!context.ThreefoldApiUris.Any()))
                    {
                        var modifiedUri = new ThreefoldApiUriEntity()
                        {
                            Name = "omniflowNode-74cu7Tf2N6h1MfCYRVJTP5LTPjZZ5ZWsyfExd5CehRAM",
                            Typ = "Nodes",
                            List = false,
                            Uri = "https://explorer.grid.tf/explorer/nodes/74cu7Tf2N6h1MfCYRVJTP5LTPjZZ5ZWsyfExd5CehRAM"
                        };
                        modifiedUris.Add(modifiedUri);
                    };

                    if (!context.ThreefoldApiUris.Any(f => f.Uri == "https://explorer.grid.tf/explorer/farms/1") || (!context.ThreefoldApiUris.Any()))
                    {
                        var modifiedUri = new ThreefoldApiUriEntity()
                        {
                            Name = "omniflowFarm-1",
                            Typ = "Farms",
                            List = false,
                            Uri = "https://explorer.grid.tf/explorer/farms/1"
                        };
                        modifiedUris.Add(modifiedUri);
                    };

                    if (!context.ThreefoldApiUris.Any(f => f.Uri == "https://explorer.grid.tf/explorer/farms/173599") || (!context.ThreefoldApiUris.Any()))
                    {
                        var modifiedUri = new ThreefoldApiUriEntity()
                        {
                            Name = "omniflowFarm-173599",
                            Typ = "Farms",
                            List = false,
                            Uri = "https://explorer.grid.tf/explorer/farms/173599"
                        };
                        modifiedUris.Add(modifiedUri);
                    };

                    if (!context.ThreefoldApiUris.Any(f => f.Uri == "https://explorer.grid.tf/explorer/farms") || (!context.ThreefoldApiUris.Any()))
                    {
                        var modifiedUri = new ThreefoldApiUriEntity()
                        {
                            Name = "AllFarms",
                            Typ = "Farms",
                            List = true,
                            Uri = "https://explorer.grid.tf/explorer/farms"
                        };
                        modifiedUris.Add(modifiedUri);
                    };

                    if (!context.ThreefoldApiUris.Any(f => f.Uri == "https://explorer.grid.tf/explorer/nodes") || (!context.ThreefoldApiUris.Any()))
                    {
                        var modifiedUri = new ThreefoldApiUriEntity()
                        {
                            Name = "AllNodes",
                            Typ = "Nodes",
                            List = true,
                            Uri = "https://explorer.grid.tf/explorer/nodes"
                        };
                        modifiedUris.Add(modifiedUri);
                    };
                }

                return modifiedUris;
            }
            catch (Exception e)
            {
                Log.Warning("Something went wrong by Creating TestUris", e);
                return null;
            }
        }
    }
}