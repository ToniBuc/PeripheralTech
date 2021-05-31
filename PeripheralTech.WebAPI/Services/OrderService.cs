using AutoMapper;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class OrderService : BaseCRUDService<Model.Order, OrderSearchRequest, Database.Order, OrderInsertRequest, OrderUpdateRequest>
    {
        public OrderService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
