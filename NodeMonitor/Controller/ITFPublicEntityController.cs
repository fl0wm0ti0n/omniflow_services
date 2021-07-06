using AutoMapper;
using NodeMonitor.Models;
using DatabaseLib.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Models.ThreeFoldModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NodeMonitor.Controller
{
    public interface ITFPublicEntityController
    {
        bool AddFarmList(List<JsonFarm> JsonFarmList);
        bool AddNodeList(List<JsonNode> JsonNodeList);
        bool AddNodeHistoryList(List<JsonNode> JsonNodeList);
        bool AddFarm(JsonFarm jsonFarm);
        bool AddNode(JsonNode JsonNode);
        bool AddNodeHistoryItem(JsonNode JsonNode);
        void AddFarmFromId(long Id);
        DateTime UnixTimeStampToDateTime(long unixTimeStamp);
        DateTime SecondsToDateTime(long secs);
    }
}