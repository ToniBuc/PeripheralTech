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
    public class StaffReviewService : BaseCRUDService<Model.StaffReview, StaffReviewSearchRequest, Database.StaffReview, StaffReviewUpsertRequest, StaffReviewUpsertRequest>
    {
        public StaffReviewService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.StaffReview> Get(StaffReviewSearchRequest request)
        {
            var query = _context.StaffReview.Include(i => i.Product).Include(i => i.User).AsQueryable();

            if (request.ProductID.HasValue)
            {
                query = query.Where(x => x.ProductID == request.ProductID);
            }

            var list = query.ToList();

            var result = _mapper.Map<List<Model.StaffReview>>(list);

            return result;
        }
    }
}
