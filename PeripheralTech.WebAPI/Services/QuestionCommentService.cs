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
    public class QuestionCommentService : BaseCRUDService<Model.QuestionComment, QuestionCommentSearchRequest, Database.QuestionComment, QuestionCommentUpsertRequest, QuestionCommentUpsertRequest>
    {
        public QuestionCommentService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.QuestionComment> Get(QuestionCommentSearchRequest request)
        {
            var query = _context.QuestionComment.Include(i => i.User).AsQueryable();

            if (request.QuestionID.HasValue)
            {
                query = query.Where(x => x.QuestionID == request.QuestionID);
            }

            query = query.OrderByDescending(x => x.Date);

            var list = query.ToList();

            var result = _mapper.Map<List<Model.QuestionComment>>(list);

            foreach (var x in result)
            {
                x.SenderName = x.User.Username;
                x.SenderWithDate = x.User.Username + " (" + x.Date.ToString() + "):";
            }

            return result;
        }
    }
}
