using AutoMapper;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class ProductImageService : BaseCRUDService<Model.ProductImage, ProductImageSearchRequest, Database.ProductImage, ProductImageUpsertRequest, ProductImageUpsertRequest>
    {
        public ProductImageService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
