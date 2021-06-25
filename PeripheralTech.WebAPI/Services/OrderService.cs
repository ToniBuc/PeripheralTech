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
    public class OrderService : BaseCRUDService<Model.Order, OrderSearchRequest, Database.Order, OrderInsertRequest, OrderUpdateRequest>
    {
        public OrderService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override List<Model.Order> Get(OrderSearchRequest request)
        {
            var query = _context.Order.Include(i => i.OrderStatus).Include(i => i.User).AsQueryable();

            if (request.UserID.HasValue && !string.IsNullOrWhiteSpace(request.OrderStatus))
            {
                query = query.Where(x => x.UserID == request.UserID && x.OrderStatus.Name.Equals(request.OrderStatus));
            }

            var list = query.ToList();

            var result = _mapper.Map<List<Model.Order>>(list);

            return result;
        }
    }
}
