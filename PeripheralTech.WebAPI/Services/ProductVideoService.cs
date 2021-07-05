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
    public class ProductVideoService : BaseCRUDService<Model.ProductVideo, ProductVideoSearchRequest, Database.ProductVideo, ProductVideoUpsertRequest, ProductVideoUpsertRequest>
    {
        public ProductVideoService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override List<Model.ProductVideo> Get(ProductVideoSearchRequest request)
        {
            var query = _context.ProductVideo.Include(i => i.Product).AsQueryable();

            query = query.Where(x => x.ProductID == request.ProductID);

            var list = query.ToList();

            var result = _mapper.Map<List<Model.ProductVideo>>(list);

            return result;
        }
    }
}
