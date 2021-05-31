using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeripheralTech.Model;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Services;

namespace PeripheralTech.WebAPI.Controllers
{
    public class StaffReviewController : BaseCRUDController<Model.StaffReview, StaffReviewSearchRequest, StaffReviewUpsertRequest, StaffReviewUpsertRequest>
    {
        public StaffReviewController(ICRUDService<StaffReview, StaffReviewSearchRequest, StaffReviewUpsertRequest, StaffReviewUpsertRequest> service) : base(service)
        {

        }
    }
}