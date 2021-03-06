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
    //public class OrderService : BaseCRUDService<Model.Order, OrderSearchRequest, Database.Order, OrderInsertRequest, OrderUpdateRequest>
    public class OrderService : IOrderService
    {
        private readonly PeripheralTechDbContext _context;
        private readonly IMapper _mapper;
        public OrderService(PeripheralTechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Order> Get(OrderSearchRequest request)
        {
            var query = _context.Order.Include(i => i.OrderStatus).Include(i => i.User).AsQueryable();

            if (request.UserID.HasValue && !string.IsNullOrWhiteSpace(request.OrderStatus))
            {
                if (request.OrderStatus.Equals("Active"))
                {
                    query = query.Where(x => x.UserID == request.UserID && x.OrderStatus.Name.Equals(request.OrderStatus));
                }
                else if (request.OrderStatus.Equals("NotActive"))
                {
                    //this might need fixing, keep it in mind
                    //query = query.Where(x => x.UserID == request.UserID && x.OrderStatus.Name.Equals("Done") || x.UserID == request.UserID && x.OrderStatus.Name.Equals("Pending
                    query = query.Where(x => x.UserID == request.UserID && !x.OrderStatus.Name.Equals("Active"));
                }
            }

            if (!request.UserID.HasValue && !string.IsNullOrWhiteSpace(request.OrderStatus))
            {
                if (request.OrderStatus.Equals("Active"))
                {
                    query = query.Where(x => x.OrderStatus.Name.Equals(request.OrderStatus));
                }
                else if (request.OrderStatus.Equals("NotActive"))
                {
                    //query = query.Where(x => x.OrderStatus.Name.Equals("Done") || x.OrderStatus.Name.Equals("Pending"));
                    query = query.Where(x => !x.OrderStatus.Name.Equals("Active"));
                }
                else if (request.OrderStatus.Equals("Done"))
                {
                    query = query.Where(x => x.OrderStatus.Name.Equals("Done"));
                }
                else if (request.OrderStatus.Equals("Pending"))
                {
                    query = query.Where(x => x.OrderStatus.Name.Equals("Pending"));
                }
                else if (request.OrderStatus.Equals("Under Review"))
                {
                    query = query.Where(x => x.OrderStatus.Name.Equals("Under Review"));
                }
                else if (request.OrderStatus.Equals("Approved"))
                {
                    query = query.Where(x => x.OrderStatus.Name.Equals("Approved"));
                }
            }
            query = query.OrderByDescending(x => x.Date);
            var list = query.ToList();

            var result = _mapper.Map<List<Model.Order>>(list);

            //for display in checkout
            if (result.Count == 1 && result[0].OrderStatus.Name == "Active")
            {
                var productList = _context.OrderProduct.Include(i => i.Product).Where(i => i.OrderID == result[0].OrderID).ToList();

                foreach (var x in productList)
                {
                    var discount = _context.Discount.Where(i => i.ProductID == x.ProductID && i.From.Date <= DateTime.Now.Date && i.To.Date >= DateTime.Now.Date).FirstOrDefault();
                    if (discount != null)
                    {
                        var discountedPrice = x.Product.Price - (x.Product.Price * discount.DiscountPercentage) / 100;
                        result[0].TotalPayment += discountedPrice;
                    }
                    else
                    {
                        result[0].TotalPayment += x.Product.Price;
                    }
                   
                }
                result[0].TotalPaymentWithCurrency = Math.Round(result[0].TotalPayment,2).ToString() + " KM";
            }

            if (result.Count != 0)
            {
                if (result.Count > 1 || result[0].OrderStatus.Name != "Active")
                {
                    foreach (var x in result)
                    {
                        var productList = _context.OrderProduct.Include(i => i.Product).Where(i => i.OrderID == x.OrderID).ToList();

                        foreach (var y in productList)
                        {
                            var discount = _context.Discount.Where(i => i.ProductID == y.ProductID && i.From.Date <= x.Date.Date && i.To.Date >= x.Date.Date).FirstOrDefault();
                            if (discount != null)
                            {
                                var discountedPrice = y.Product.Price - (y.Product.Price * discount.DiscountPercentage) / 100;
                                x.TotalPayment += discountedPrice;
                            }
                            else
                            {
                                x.TotalPayment += y.Product.Price;
                            }

                            if (x.AmountOfProducts != null)
                            {
                                x.AmountOfProducts += 1;
                            }
                            else
                            {
                                x.AmountOfProducts = 1;
                            }
                        }
                        x.UserFullname = x.User.FirstName + " \"" + x.User.Username + "\" " + x.User.LastName;
                        x.DateShort = x.Date.ToShortDateString();
                        x.OrderStatusName = x.OrderStatus.Name;
                        x.TotalPaymentWithCurrency = Math.Round(x.TotalPayment,2).ToString() + " KM";
                    }
                }
            }
            

            return result;
        }

        public Model.Order GetById(int id)
        {
            var entity = _context.Order.Where(i => i.OrderID == id).Include(i => i.User).Include(i => i.User.City).Include(i => i.OrderStatus).FirstOrDefault();

            var result = _mapper.Map<Model.Order>(entity);

            result.DateShort = result.Date.ToShortDateString();

            var productList = _context.OrderProduct.Include(i => i.Product).Where(i => i.OrderID == id).ToList();

            foreach (var x in productList)
            {
                var discount = _context.Discount.Where(i => i.ProductID == x.ProductID && i.From.Date <= result.Date.Date && i.To.Date >= result.Date.Date).FirstOrDefault();
                if (discount != null)
                {
                    var discountedPrice = x.Product.Price - (x.Product.Price * discount.DiscountPercentage) / 100;
                    result.TotalPayment += discountedPrice;
                }
                else
                {
                    result.TotalPayment += x.Product.Price;
                }
            }

            result.OrderStatusName = result.OrderStatus.Name;
            result.UserFullname = result.User.FirstName + " \"" + result.User.Username + "\" " + result.User.LastName;

            return result;
        }
        public Model.Order GetUnderReviewOrder(OrderSearchRequest request)
        {
            var query = _context.Order.Include(i => i.OrderStatus).Include(i => i.User).AsQueryable();

            query = query.Where(x => x.UserID == request.UserID && x.OrderStatus.Name.Equals("Under Review"));

            var order = query.FirstOrDefault();

            var result = _mapper.Map<Model.Order>(order);

            return result;
        }

        public Model.Order GetApprovedOrder(OrderSearchRequest request)
        {
            var query = _context.Order.Include(i => i.OrderStatus).Include(i => i.User).AsQueryable();

            query = query.Where(x => x.UserID == request.UserID && x.OrderStatus.Name.Equals("Approved"));

            var order = query.FirstOrDefault();

            var result = _mapper.Map<Model.Order>(order);

            return result;
        }

        public Model.Order Update(int id, OrderUpdateRequest request)
        {
            var entity = _context.Order.Find(id);
            _context.Order.Attach(entity);
            _context.Order.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Order>(entity);
        }
        public Model.Order Insert(OrderInsertRequest request)
        {
            var entity = _mapper.Map<Database.Order>(request);

            _context.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Order>(entity);
        }
    }
}
