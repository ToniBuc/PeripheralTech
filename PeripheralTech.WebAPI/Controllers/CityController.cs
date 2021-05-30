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
    public class CityController : BaseCRUDController<Model.City, CitySearchRequest, CityUpsertRequest, CityUpsertRequest>
    {
        public CityController(ICRUDService<City, CitySearchRequest, CityUpsertRequest, CityUpsertRequest> service) : base(service)
        {

        }
    }
}