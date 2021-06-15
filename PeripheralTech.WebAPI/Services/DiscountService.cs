using AutoMapper;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class DiscountService : BaseCRUDService<Model.Discount, DiscountSearchRequest, Database.Discount, DiscountUpsertRequest, DiscountUpsertRequest>
    {
        public DiscountService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override List<Model.Discount> Get(DiscountSearchRequest request)
        {
            var query = _context.Discount.AsQueryable();

            if (request.ProductID != null)
            {
                query = query.Where(x => x.ProductID == request.ProductID);
            }

            var list = query.ToList();

            var result = _mapper.Map<List<Model.Discount>>(list);

            foreach (var x in result)
            {
                x.DiscountPercentageString = Convert.ToInt32(x.DiscountPercentage).ToString() + "%";
                x.FromShortDateString = x.From.ToShortDateString();
                x.ToShortDateString = x.To.ToShortDateString();

                if (x.From.Date <= DateTime.Now.Date && DateTime.Now.Date <= x.To.Date)
                {
                    x.Active = true;
                }
                else
                {
                    x.Active = false;
                }
            }

            return result;
        }
    }
}
