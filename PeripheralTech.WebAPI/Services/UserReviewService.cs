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
    public class UserReviewService : BaseCRUDService<Model.UserReview, UserReviewSearchRequest, Database.UserReview, UserReviewUpsertRequest, UserReviewUpsertRequest>
    {
        public UserReviewService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.UserReview> Get(UserReviewSearchRequest request)
        {
            var query = _context.UserReview.Include(i => i.User).AsQueryable();

            if (request.ProductID.HasValue)
            {
                query = query.Where(x => x.ProductID == request.ProductID);
            }

            var list = query.ToList();

            var result = _mapper.Map<List<Model.UserReview>>(list);

            foreach(var x in result)
            {
                x.Username = x.User.Username;
                x.GradeInteger = Convert.ToInt32(x.Grade);
            }

            return result;
        }
    }
}
