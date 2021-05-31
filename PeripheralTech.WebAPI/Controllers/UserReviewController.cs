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
    public class UserReviewController : BaseCRUDController<Model.UserReview, UserReviewSearchRequest, UserReviewUpsertRequest, UserReviewUpsertRequest>
    {
        public UserReviewController(ICRUDService<UserReview, UserReviewSearchRequest, UserReviewUpsertRequest, UserReviewUpsertRequest> service) : base(service)
        {

        }
    }
}