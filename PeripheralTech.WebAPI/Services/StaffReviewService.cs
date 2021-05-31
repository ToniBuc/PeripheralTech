using AutoMapper;
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
    }
}
