using AutoMapper;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class DiscountService : BaseCRUDService<Model.Discount, DiscountSearchRequest, Database.UserReview, DiscountUpsertRequest, DiscountUpsertRequest>
    {
        public DiscountService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
