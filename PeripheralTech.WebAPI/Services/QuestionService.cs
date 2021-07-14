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
                else if (request.StaffID.HasValue)
                {
                    query = query.Where(x => x.StaffID == request.StaffID);
                }
            }

            if (request.StaffID.HasValue)
            {
                query = query.Where(x => x.StaffID == request.StaffID);
            }

            if (request.CustomerID.HasValue)
            {
                query = query.Where(x => x.CustomerID == request.CustomerID);
            }

            if (request.OrderID.HasValue)
            {
                query = query.Where(x => x.OrderID == request.OrderID);
            }

            query = query.OrderByDescending(x => x.Date);

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
                x.DateShortString = x.Date.ToShortDateString();
                if (x.Status == true)
                {
                    x.StatusString = "Open";
                }
                else
                {
                    x.StatusString = "Closed";
                }
            }

            return result;
        }

        public override Model.Question Update(int id, QuestionUpdateRequest request)
        {
            var entity = _context.Question.Find(id);

            _context.Question.Attach(entity);
            _context.Question.Update(entity);

            if (!request.StaffID.HasValue && entity.StaffID.HasValue)
            {
                request.StaffID = entity.StaffID;
            }

            if (!request.Status.HasValue)
            {
                request.Status = true;
            }

            _mapper.Map(request, entity);

            if (request.StaffID.HasValue && !entity.StaffID.HasValue)
            {
                entity.StaffID = request.StaffID;
            }

            //false means that the question is inactive (closed), while true means it's active (open)
            if (request.Status.HasValue)
            {
                entity.Status = request.Status.Value;
            }

            _context.SaveChanges();

            return _mapper.Map<Model.Question>(entity);
        }
    }
}
