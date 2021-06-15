using AutoMapper;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public class QuestionService : BaseCRUDService<Model.Question, QuestionSearchRequest, Database.Question, QuestionUpsertRequest, QuestionUpsertRequest>
    {
        public QuestionService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
