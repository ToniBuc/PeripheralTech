using AutoMapper;
using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.City, Model.City>();
            CreateMap<Database.City, CityUpsertRequest>().ReverseMap();
        }
    }
}
