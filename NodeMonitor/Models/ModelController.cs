using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using DatabaseLib.Entities;
using NodeMonitor.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NodeMonitor.Models
{
    public class ModelController
    {
        private readonly nmDBContext _context;
        private readonly IMapper _mapper;

        public ModelController(nmDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public void AddFarm(JsonNode JsonFarm)
        {
            using (var context = new nmDBContext())
            {
                context.Farms.Persist(_mapper).InsertOrUpdate(JsonFarm);
                context.SaveChanges();
            }

            FarmEntity NewFarm = new FarmEntity()
            {
                //NodeEntity.FarmId = JsonNode.
            };
        }
    }
}
