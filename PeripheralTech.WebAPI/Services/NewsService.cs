using AutoMapper;
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
    }
}
