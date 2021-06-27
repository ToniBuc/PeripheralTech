using AutoMapper;
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
    }
}
