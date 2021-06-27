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
    public class BillController : BaseCRUDController<Model.Bill, BillSearchRequest, BillUpsertRequest, BillUpsertRequest>
    {
        public BillController(ICRUDService<Bill, BillSearchRequest, BillUpsertRequest, BillUpsertRequest> service) : base(service)
        {

        }
    }
}