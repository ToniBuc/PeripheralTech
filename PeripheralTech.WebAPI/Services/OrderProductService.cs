﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        public override List<Model.OrderProduct> Get(OrderProductSearchRequest request)
        {
            var query = _context.OrderProduct.Include(i => i.Product).Include(i => i.Order).Include(i => i.Order.OrderStatus).AsQueryable();

            if (request.ProductID.HasValue)
            {
                query = query.Where(x => x.ProductID == request.ProductID && x.Order.OrderStatus.Name.Equals("Active"));
            }

            var list = query.ToList();

            var result = _mapper.Map<List<Model.OrderProduct>>(list);

            return result;
        }
    }
}
