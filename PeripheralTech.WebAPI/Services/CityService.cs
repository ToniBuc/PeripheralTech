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
    public class CityService : BaseCRUDService<Model.City, CitySearchRequest, Database.City, CityUpsertRequest, CityUpsertRequest>
    {
        public CityService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.City> Get(CitySearchRequest request)
        {
            var query = _context.City.Include(i => i.Country).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.CityName))
            {
                query = query.Where(x => x.Name.Contains(request.CityName));
            }

            var list = query.ToList();

            var result = _mapper.Map<List<Model.City>>(list);

            foreach(var x in result)
            {
                x.CountryName = x.Country.Name;
            }

            return result;
        }
    }
}
