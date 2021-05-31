using AutoMapper;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class ProductService : BaseCRUDService<Model.Product, ProductSearchRequest, Database.Product, ProductUpsertRequest, ProductUpsertRequest>
    {
        public ProductService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
