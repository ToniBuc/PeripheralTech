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
    //public class ProductService : BaseCRUDService<Model.Product, ProductSearchRequest, Database.Product, ProductUpsertRequest, ProductUpsertRequest>
    public class ProductService : IProductService
    {
        private readonly PeripheralTechDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(PeripheralTechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Product> Get(ProductSearchRequest request)
        {
            var query = _context.Product.Include(i => i.ProductType).Include(i => i.Company).Include(i => i.ProductMadeFor).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.ProductName))
            {
                query = query.Where(x => x.Name.Contains(request.ProductName));
            }

            if (request?.ProductTypeID.HasValue == true)
            {
                query = query.Where(x => x.ProductTypeID == request.ProductTypeID);
            }

            if (request?.CompanyID.HasValue == true)
            {
                query = query.Where(x => x.CompanyID == request.CompanyID);
            }

            if (!string.IsNullOrWhiteSpace(request.InStock) && request.InStock != "All")
            {
                if (request.InStock == "In stock")
                {
                    query = query.Where(x => x.AmountInStock > 0);
                }
                else if (request.InStock == "Out of stock")
                {
                    query = query.Where(x => x.AmountInStock == 0);
                }
            }

            if (!string.IsNullOrWhiteSpace(request.OrderByPrice) && request.OrderByPrice != "All")
            {
                if (request.OrderByPrice == "Low to High")
                {
                    query = query.OrderBy(x => x.Price);
                }
                else if (request.OrderByPrice == "High to Low")
                {
                    query = query.OrderByDescending(x => x.Price);
                }
            }

            if (request.AmountInStock.HasValue)
            {
                query = query.Where(x => x.AmountInStock == request.AmountInStock);
            }

            if (request.ProductID.HasValue)
            {
                query = query.Where(x => x.ProductID == request.ProductID);
            }

            if (request.AvailableForCustom)
            {
                query = query.Where(x => x.AvailableForCustom == true);
            }

            var list = query.ToList();

            var result = _mapper.Map<List<Model.Product>>(list);

            foreach (var x in result)
            {
                x.CompanyName = x.Company.Name;
                x.ProductTypeName = x.ProductType.Name;
                var discount = _context.Discount.Where(i => i.ProductID == x.ProductID && i.From.Date <= DateTime.Now.Date && i.To.Date >= DateTime.Now.Date).FirstOrDefault();
                if (discount != null)
                {
                    var discountedPrice = x.Price - (x.Price * discount.DiscountPercentage) / 100;
                    x.ProductNamePrice = x.Name + " - " + Math.Round(discountedPrice, 2) + " KM";
                    x.Discounted = true;
                    x.DiscountedString = " (-" + Math.Round(discount.DiscountPercentage, 0) + "% from " + x.Price + ") KM";
                    //x.DiscountedPrice = discountedPrice.ToString();
                }
                else
                {
                    x.ProductNamePrice = x.Name + " - " + x.Price.ToString() + " KM";
                }
                x.PriceWithCurrency = x.Price.ToString() + " KM";
            }

            return result;
        }

        public Model.Product GetById(int id)
        {
            var entity = _context.Product.Where(i => i.ProductID == id).Include(i => i.ProductType).Include(i => i.Company).Include(i => i.ProductMadeFor).FirstOrDefault();

            var result = _mapper.Map<Model.Product>(entity);

            result.CompanyName = result.Company.Name;
            result.ProductTypeName = result.ProductType.Name;

            var discount = _context.Discount.Where(i => i.ProductID == result.ProductID && i.From.Date <= DateTime.Now.Date && i.To.Date >= DateTime.Now.Date).FirstOrDefault();
            if (discount != null)
            {
                var discountedPrice = result.Price - (result.Price * discount.DiscountPercentage) / 100;
                result.ProductNamePrice = result.Name + " - " + Math.Round(discountedPrice, 2) + " KM";
                result.Discounted = true;
                result.DiscountedString = " (-" + Math.Round(discount.DiscountPercentage, 0) + "% from " + result.Price + ") KM";
                result.DiscountedPrice = Math.Round(discountedPrice, 2).ToString();
            }
            else
            {
                result.ProductNamePrice = result.Name + " - " + result.Price.ToString() + " KM";
            }

            return result;
        }

        public Model.Product Update(int id, ProductUpsertRequest request)
        {
            var entity = _context.Product.Find(id);
            if (request.Thumbnail == null)
            {
                request.Thumbnail = entity.Thumbnail;
            }
            if (request.ProductMadeForID == null)
            {
                request.ProductMadeForID = entity.ProductMadeForID;
            }
            _context.Product.Attach(entity);
            _context.Product.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Product>(entity);
        }

        public List<Model.Product> GetRecentProducts(ProductSearchRequest search)
        {
            var query = _context.Set<Database.Product>().AsQueryable();

            query = query.Where(i => i.AmountInStock != 0);

            var list = query.ToList().OrderByDescending(i => i.ProductID).Take(3);
            list = list.OrderByDescending(i => i.Name.Length);
            var result = _mapper.Map<List<Model.Product>>(list);

            foreach (var x in result)
            {
                var discount = _context.Discount.Where(i => i.ProductID == x.ProductID && i.From.Date <= DateTime.Now.Date && i.To.Date >= DateTime.Now.Date).FirstOrDefault();
                if (discount != null)
                {
                    var discountedPrice = x.Price - (x.Price * discount.DiscountPercentage) / 100;
                    x.ProductNamePrice = x.Name + " - " + Math.Round(discountedPrice, 2) + " KM";
                    x.Discounted = true;
                    x.DiscountedString = " (-" + Math.Round(discount.DiscountPercentage, 0) + "% from " + x.Price + ") KM";
                }
                else
                {
                    x.ProductNamePrice = x.Name + " - " + x.Price.ToString() + " KM";
                }
            }

            return result;
        }

        public List<Model.Product> GetDiscountedProducts(ProductSearchRequest search)
        {
            var query = _context.Set<Database.Product>().AsQueryable();

            query = query.Where(i => i.AmountInStock != 0);

            var list = query.ToList().OrderByDescending(i => i.Name.Length);
            var result = _mapper.Map<List<Model.Product>>(list);
            var realResult = new List<Model.Product>();

            foreach (var x in result)
            {
                var discount = _context.Discount.Where(i => i.ProductID == x.ProductID && i.From.Date <= DateTime.Now.Date && i.To.Date >= DateTime.Now.Date).FirstOrDefault();
                if (discount != null)
                {
                    var discountedPrice = x.Price - (x.Price * discount.DiscountPercentage) / 100;
                    x.ProductNamePrice = x.Name + " - " + Math.Round(discountedPrice, 2) + " KM";
                    x.Discounted = true;
                    x.DiscountedString = " (-" + Math.Round(discount.DiscountPercentage, 0) + "% from " + x.Price + ") KM";
                    realResult.Add(x);
                }
            }

            return realResult;
        }

        public List<Model.Product> GetCustomizableProducts(ProductSearchRequest search)
        {
            var query = _context.Set<Database.Product>().Include(i => i.ProductType).AsQueryable();

            query = query.Where(i => i.AmountInStock > 0 && i.AvailableForCustom == true);

            var list = query.ToList();
            var result = _mapper.Map<List<Model.Product>>(list);

            foreach (var x in result)
            {
                var discount = _context.Discount.Where(i => i.ProductID == x.ProductID && i.From.Date <= DateTime.Now.Date && i.To.Date >= DateTime.Now.Date).FirstOrDefault();
                if (discount != null)
                {
                    var discountedPrice = x.Price - (x.Price * discount.DiscountPercentage) / 100;
                    x.ProductNamePrice = x.Name + " - " + Math.Round(discountedPrice, 2) + " KM";
                    x.Discounted = true;
                    x.DiscountedString = " (-" + Math.Round(discount.DiscountPercentage, 0) + "% from " + x.Price + ") KM";
                }
                else
                {
                    x.ProductNamePrice = x.Name + " - " + x.Price.ToString() + " KM";
                }
                x.ProductTypeName = x.ProductType.Name;
            }

            return result;
        }

        public List<Model.Product> GetProductsForCustomOrder(ProductSearchRequest search)
        {
            var query = _context.Set<Database.Product>().Include(i => i.ProductType).AsQueryable();

            query = query.Where(i => i.AmountInStock != 0 && i.ProductMadeForID == search.ProductID);

            var list = query.ToList();
            var result = _mapper.Map<List<Model.Product>>(list);

            foreach (var x in result)
            {
                var discount = _context.Discount.Where(i => i.ProductID == x.ProductID && i.From.Date <= DateTime.Now.Date && i.To.Date >= DateTime.Now.Date).FirstOrDefault();
                if (discount != null)
                {
                    var discountedPrice = x.Price - (x.Price * discount.DiscountPercentage) / 100;
                    x.ProductNamePrice = x.Name + " - " + Math.Round(discountedPrice, 2) + " KM";
                    x.Discounted = true;
                    x.DiscountedString = " (-" + Math.Round(discount.DiscountPercentage, 0) + "% from " + x.Price + ") KM";
                }
                else
                {
                    x.ProductNamePrice = x.Name + " - " + x.Price.ToString() + " KM";
                }
                x.ProductTypeName = x.ProductType.Name;
            }

            return result;
        }

        public Model.Product Insert(ProductUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Product>(request);

            _context.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.Product>(entity);
        }
    }
}
