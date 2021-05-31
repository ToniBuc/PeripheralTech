using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeripheralTech.Model;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Services;

namespace PeripheralTech.WebAPI.Controllers
{
    public class UserFavoriteProductController : BaseCRUDController<Model.UserFavoriteProduct, UserFavoriteProductSearchRequest, UserFavoriteProductUpsertRequest, UserFavoriteProductUpsertRequest>
    {
        public UserFavoriteProductController(ICRUDService<UserFavoriteProduct, UserFavoriteProductSearchRequest, UserFavoriteProductUpsertRequest, UserFavoriteProductUpsertRequest> service) : base(service)
        {

        }
    }
}