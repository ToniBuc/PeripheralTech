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
    }
}
