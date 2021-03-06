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
    public class QuestionController : BaseCRUDController<Model.Question, QuestionSearchRequest, QuestionInsertRequest, QuestionUpdateRequest>
    {
        public QuestionController(ICRUDService<Question, QuestionSearchRequest, QuestionInsertRequest, QuestionUpdateRequest> service) : base(service)
        {

        }
    }
}