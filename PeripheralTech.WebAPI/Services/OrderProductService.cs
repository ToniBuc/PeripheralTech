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

            if (request.OrderID.HasValue && !request.MyOrdersCheck)
            {
                if (!request.CustomOrderProductsCheck)
                {
                    query = query.Where(x => x.OrderID == request.OrderID && x.Order.OrderStatus.Name.Equals("Active"));
                }
                //query = query.Where(x => x.OrderID == request.OrderID && x.Order.OrderStatus.Name.Equals("Active"));
            }

            if (request.OrderID.HasValue && request.MyOrdersCheck)
            {
                //query = query.Where(x => x.OrderID == request.OrderID && x.Order.OrderStatus.Name.Equals("Done") || x.OrderID == request.OrderID && x.Order.OrderStatus.Name.Equals("Pending"));
                query = query.Where(x => x.OrderID == request.OrderID && !x.Order.OrderStatus.Name.Equals("Active"));
            }

            if (request.OrderID.HasValue && request.CustomOrderProductsCheck)
            {
                query = query.Where(x => x.OrderID == request.OrderID);
            }

            var list = query.ToList();

            var result = _mapper.Map<List<Model.OrderProduct>>(list);

            foreach (var x in result)
            {
                x.ProductNameAndPrice = x.Product.Name + " (" + x.Product.Price + ")";
                x.Thumbnail = x.Product.Thumbnail;
                x.ProductName = x.Product.Name;
                x.ProductPrice = x.Product.Price.ToString();

                Discount discount = null;
                if (!request.MyOrdersCheck)
                {
                    discount = _context.Discount.Where(i => i.ProductID == x.ProductID && i.From.Date <= DateTime.Now.Date && i.To.Date >= DateTime.Now.Date).FirstOrDefault();
                }
                else
                {
                    discount = _context.Discount.Where(i => i.ProductID == x.ProductID && i.From.Date <= x.Order.Date.Date && i.To.Date >= x.Order.Date.Date).FirstOrDefault();
                }

                if (discount != null)
                {
                    var discountedPrice = x.Product.Price - (x.Product.Price * discount.DiscountPercentage) / 100;
                    x.ProductNameAndPrice = x.Product.Name + " - " + Math.Round(discountedPrice, 2) + " KM";
                    x.Discounted = true;
                    x.DiscountedString = " (-" + Math.Round(discount.DiscountPercentage, 0) + "% from " + x.Product.Price + ") + KM";
                    x.DiscountedPrice = discountedPrice;
                    x.FinalPrice = Math.Round(discountedPrice,2).ToString() + " KM";
                }
                else
                {
                    x.ProductNameAndPrice = x.Product.Name + " - " + x.Product.Price.ToString() + " KM";
                    x.FinalPrice = x.Product.Price.ToString() + " KM";
                }
            }

            return result;
        }
    }
}
