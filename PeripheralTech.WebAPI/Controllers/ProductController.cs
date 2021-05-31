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
    public class ProductController : BaseCRUDController<Model.Product, ProductSearchRequest, ProductUpsertRequest, ProductUpsertRequest>
    {
        public ProductController(ICRUDService<Product, ProductSearchRequest, ProductUpsertRequest, ProductUpsertRequest> service) : base(service)
        {

        }
    }
}