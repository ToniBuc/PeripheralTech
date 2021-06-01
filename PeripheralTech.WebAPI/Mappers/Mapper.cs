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
            CreateMap<Database.UserFavoriteProduct, Model.UserFavoriteProduct>();
            CreateMap<Database.UserFavoriteProduct, UserFavoriteProductUpsertRequest>().ReverseMap();
            CreateMap<Database.UserReview, Model.UserReview>();
            CreateMap<Database.UserReview, UserReviewUpsertRequest>().ReverseMap();
            CreateMap<Database.StaffReview, Model.StaffReview>();
            CreateMap<Database.StaffReview, StaffReviewUpsertRequest>().ReverseMap();
            CreateMap<Database.ProductImage, Model.ProductImage>();
            CreateMap<Database.ProductImage, ProductImageUpsertRequest>().ReverseMap();
            CreateMap<Database.ProductVideo, Model.ProductVideo>();
            CreateMap<Database.ProductVideo, ProductVideoUpsertRequest>().ReverseMap();
            CreateMap<Database.Discount, Model.Discount>();
            CreateMap<Database.Discount, DiscountUpsertRequest>().ReverseMap();
            CreateMap<Database.OrderProduct, Model.OrderProduct>();
            CreateMap<Database.OrderProduct, OrderProductUpsertRequest>().ReverseMap();
        }
    }
}
