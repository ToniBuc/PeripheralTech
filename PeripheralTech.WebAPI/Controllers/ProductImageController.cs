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
    public class ProductImageController : BaseCRUDController<Model.ProductImage, ProductImageSearchRequest, ProductImageUpsertRequest, ProductImageUpsertRequest>
    {
        public ProductImageController(ICRUDService<ProductImage, ProductImageSearchRequest, ProductImageUpsertRequest, ProductImageUpsertRequest> service) : base(service)
        {

        }
    }
}