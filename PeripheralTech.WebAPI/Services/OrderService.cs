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

            //for display in checkout
            if (result.Count == 1 && result[0].OrderStatus.Name == "Active")
            {
                var productList = _context.OrderProduct.Include(i => i.Product).Where(i => i.OrderID == result[0].OrderID).ToList();

                foreach (var x in productList)
                {
                    result[0].TotalPayment += x.Product.Price;
                }
            }

            if (result.Count != 0)
            {
                if (result.Count > 1 || result[0].OrderStatus.Name == "Done")
                {
                    foreach (var x in result)
                    {
                        var productList = _context.OrderProduct.Include(i => i.Product).Where(i => i.OrderID == x.OrderID).ToList();

                        foreach (var y in productList)
                        {
                            x.TotalPayment += y.Product.Price;
                        }

                        x.DateShort = x.Date.ToShortDateString();
                    }
                }
            }
            

            return result;
        }

        public override Model.Order GetById(int id)
        {
            var entity = _context.Order.Where(i => i.OrderID == id).FirstOrDefault();

            var result = _mapper.Map<Model.Order>(entity);

            result.DateShort = result.Date.ToShortDateString();

            var productList = _context.OrderProduct.Include(i => i.Product).Where(i => i.OrderID == id).ToList();

            foreach (var x in productList)
            {
                result.TotalPayment += x.Product.Price;
            }

            return result;
        }
    }
}
