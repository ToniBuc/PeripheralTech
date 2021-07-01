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
    public class BillService : BaseCRUDService<Model.Bill, BillSearchRequest, Database.Bill, BillUpsertRequest, BillUpsertRequest>
    {
        public BillService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override List<Model.Bill> Get(BillSearchRequest search)
        {
            var query = _context.Set<Database.Bill>().Include(i => i.Order).Include(i => i.Order.User).AsQueryable();

            //for reports
            query = query.Where(x => x.Date.Date >= search.From.Date && x.Date.Date <= search.To.Date);

            query = query.OrderBy(x => x.Date);

            var list = query.ToList();

            var result = _mapper.Map<List<Model.Bill>>(list);

            foreach (var x in result)
            {
                x.UserFullname = x.Order.User.FirstName + " \"" + x.Order.User.Username + "\" " + x.Order.User.LastName;
            }

            return result;
        }
    }
}
