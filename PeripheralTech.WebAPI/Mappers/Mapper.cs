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
            CreateMap<Database.Country, Model.Country>();
            CreateMap<Database.ProductType, Model.ProductType>();
            CreateMap<Database.UserRole, Model.UserRole>();
            CreateMap<Database.OrderStatus, Model.OrderStatus>();

            CreateMap<Database.City, Model.City>();
            CreateMap<Database.City, CityUpsertRequest>().ReverseMap();
            CreateMap<Database.Product, Model.Product>();
            CreateMap<Database.Product, ProductUpsertRequest>().ReverseMap();
            CreateMap<Database.Company, Model.Company>();
            CreateMap<Database.Company, CompanyUpsertRequest>().ReverseMap();
            CreateMap<Database.Order, Model.Order>();
            CreateMap<Database.Order, OrderInsertRequest>().ReverseMap();
            CreateMap<Database.Order, OrderUpdateRequest>().ReverseMap();
            CreateMap<Database.User, Model.User>();
            CreateMap<Database.User, UserInsertRequest>().ReverseMap();
            CreateMap<Database.User, UserUpdateRequest>().ReverseMap();
        }
    }
}
