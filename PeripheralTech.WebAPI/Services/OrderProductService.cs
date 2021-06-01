using AutoMapper;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class OrderProductService : BaseCRUDService<Model.OrderProduct, OrderProductSearchRequest, Database.OrderProduct, OrderProductUpsertRequest, OrderProductUpsertRequest>
    {
        public OrderProductService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
