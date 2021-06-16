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
    public class QuestionService : BaseCRUDService<Model.Question, QuestionSearchRequest, Database.Question, QuestionInsertRequest, QuestionUpdateRequest>
    {
        public QuestionService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.Question> Get(QuestionSearchRequest request)
        {
            var query = _context.Question.Include(i => i.Customer).Include(i => i.Staff).AsQueryable();

            if (request.Status.HasValue)
            {
                query = query.Where(x => x.Status == request.Status);
            }
            if (request.Claim != "All")
            {
                if (request.Claim == "Claimed")
                {
                    query = query.Where(x => x.StaffID.HasValue);
                }
                else if (request.Claim == "Unclaimed")
                {
                    query = query.Where(x => !x.StaffID.HasValue);
                }
            }

            var list = query.ToList();

            var result = _mapper.Map<List<Model.Question>>(list);

            foreach (var x in result)
            {
                x.CustomerName = x.Customer.Username;
                if (x.StaffID.HasValue)
                {
                    x.StaffName = x.Staff.FirstName + " \"" + x.Staff.Username + "\" " + x.Staff.LastName;
                }
                else
                {
                    x.StaffName = "UNCLAIMED";
                }
            }

            return result;
        }
    }
}
