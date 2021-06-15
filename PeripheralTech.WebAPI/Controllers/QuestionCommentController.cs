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
    public class QuestionCommentController : BaseCRUDController<Model.QuestionComment, QuestionCommentSearchRequest, QuestionCommentUpsertRequest, QuestionCommentUpsertRequest>
    {
        public QuestionCommentController(ICRUDService<QuestionComment, QuestionCommentSearchRequest, QuestionCommentUpsertRequest, QuestionCommentUpsertRequest> service) : base(service)
        {

        }
    }
}