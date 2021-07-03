using AutoMapper;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class CompanyService : BaseCRUDService<Model.Company, CompanySearchRequest, Database.Company, CompanyUpsertRequest, CompanyUpsertRequest>
    {
        public CompanyService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.Company> Get(CompanySearchRequest request)
        {
            var query = _context.Company.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.CompanyName))
            {
                query = query.Where(x => x.Name.Contains(request.CompanyName));
            }

            var list = query.ToList();

            var result = _mapper.Map<List<Model.Company>>(list);

            foreach(var x in result)
            {
                x.NumberOfSales = _context.OrderProduct.Where(i => i.Product.CompanyID == x.CompanyID && !i.Order.OrderStatus.Name.Equals("Active")
                                                                    && i.Order.Date.Date >= request.From.Date && i.Order.Date.Date <= request.To.Date).Count();
            }

            return result;
        }
    }
}
