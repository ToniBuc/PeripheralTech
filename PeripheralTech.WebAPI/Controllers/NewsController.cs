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
    public class NewsController : BaseCRUDController<Model.News, NewsSearchRequest, NewsUpsertRequest, NewsUpsertRequest>
    {
        public NewsController(ICRUDService<News, NewsSearchRequest, NewsUpsertRequest, NewsUpsertRequest> service) : base(service)
        {

        }
    }
}