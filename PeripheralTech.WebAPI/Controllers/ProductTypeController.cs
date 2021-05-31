using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeripheralTech.Model;
using PeripheralTech.WebAPI.Services;

namespace PeripheralTech.WebAPI.Controllers
{
    public class ProductTypeController : BaseController<Model.ProductType, object>
    {
        public ProductTypeController(IService<ProductType, object> service) : base(service)
        {

        }
    }
}