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
    public class CompanyController : BaseCRUDController<Model.Company, CompanySearchRequest, CompanyUpsertRequest, CompanyUpsertRequest>
    {
        public CompanyController(ICRUDService<Company, CompanySearchRequest, CompanyUpsertRequest, CompanyUpsertRequest> service) : base(service)
        {

        }
    }
}