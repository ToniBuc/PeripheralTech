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
    public class NewsService : BaseCRUDService<Model.News, NewsSearchRequest, Database.News, NewsUpsertRequest, NewsUpsertRequest>
    {
        public NewsService(PeripheralTechDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<Model.News> Get(NewsSearchRequest request)
        {
            var query = _context.News.Include(i => i.User).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                query = query.Where(x => x.Title.Contains(request.Title));
            }

            if (!string.IsNullOrWhiteSpace(request.Author))
            {
                query = query.Where(x => x.User.FirstName.Contains(request.Author) || 
                                        x.User.Username.Contains(request.Author) ||
                                        x.User.LastName.Contains(request.Author));
            }

            var list = query.ToList();

            var result = _mapper.Map<List<Model.News>>(list);

            foreach (var x in result)
            {
                x.Author = x.User.FirstName + " \"" + x.User.Username + "\" " + x.User.LastName;
            }

            return result;
        }

        public override Model.News Update(int id, NewsUpsertRequest request)
        {
            var entity = _context.News.Find(id);
            if (request.Thumbnail == null)
            {
                request.Thumbnail = entity.Thumbnail;
            }
            _context.News.Attach(entity);
            _context.News.Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.News>(entity);
        }
    }
}
