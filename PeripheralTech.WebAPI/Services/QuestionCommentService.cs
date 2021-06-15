using AutoMapper;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class QuestionCommentService : BaseCRUDService<Model.QuestionComment, QuestionCommentSearchRequest, Database.QuestionComment, QuestionCommentUpsertRequest, QuestionCommentUpsertRequest>
    {
        public QuestionCommentService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
