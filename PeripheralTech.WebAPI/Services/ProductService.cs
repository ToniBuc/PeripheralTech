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
    public class ProductService : BaseCRUDService<Model.Product, ProductSearchRequest, Database.Product, ProductUpsertRequest, ProductUpsertRequest>
    {
        public ProductService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.Product> Get(ProductSearchRequest request)
        {
            var query = _context.Product.Include(i => i.ProductType).Include(i => i.Company).AsQueryable();

            //if (!string.IsNullOrWhiteSpace(request.CityName))
            //{
            //    query = query.Where(x => x.Name.Contains(request.CityName));
            //}

            var list = query.ToList();

            var result = _mapper.Map<List<Model.Product>>(list);

            foreach (var x in result)
            {
                //x.CountryName = x.Country.Name;
                x.CompanyName = x.Company.Name;
                x.ProductTypeName = x.ProductType.Name;
            }

            return result;
        }

        public override Model.Product GetById(int id)
        {
            var entity = _context.Product.Where(i => i.ProductID == id).Include(i => i.ProductType).Include(i => i.Company).FirstOrDefault();

            var result = _mapper.Map<Model.Product>(entity);

            result.CompanyName = result.Company.Name;
            result.ProductTypeName = result.ProductType.Name;

            return result;
        }

        public override Model.Product Update(int id, ProductUpsertRequest request)
        {
            var entity = _context.Product.Find(id);
            if (request.Thumbnail == null)
            {
                request.Thumbnail = entity.Thumbnail;
            }
            _context.Product.Attach(entity);
            _context.Product.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Product>(entity);
        }
    }
}
