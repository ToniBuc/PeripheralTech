using AutoMapper;
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
    }
}
