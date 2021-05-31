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
    public class ProductVideoController : BaseCRUDController<Model.ProductVideo, ProductVideoSearchRequest, ProductVideoUpsertRequest, ProductVideoUpsertRequest>
    {
        public ProductVideoController(ICRUDService<ProductVideo, ProductVideoSearchRequest, ProductVideoUpsertRequest, ProductVideoUpsertRequest> service) : base(service)
        {

        }
    }
}