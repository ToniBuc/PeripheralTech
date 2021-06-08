using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public override List<Model.ProductImage> Get(ProductImageSearchRequest request)
        {
            var query = _context.ProductImage.Include(i => i.Product).AsQueryable();

            var list = query.ToList();

            var result = _mapper.Map<List<Model.ProductImage>>(list);

            return result;
        }
    }
}
