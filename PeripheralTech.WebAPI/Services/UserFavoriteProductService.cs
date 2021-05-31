using AutoMapper;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class UserFavoriteProductService : BaseCRUDService<Model.UserFavoriteProduct, UserFavoriteProductSearchRequest, Database.UserFavoriteProduct, UserFavoriteProductUpsertRequest, UserFavoriteProductUpsertRequest>
    {
        public UserFavoriteProductService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
