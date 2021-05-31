using AutoMapper;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class UserReviewService : BaseCRUDService<Model.UserReview, UserReviewSearchRequest, Database.UserReview, UserReviewUpsertRequest, UserReviewUpsertRequest>
    {
        public UserReviewService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
