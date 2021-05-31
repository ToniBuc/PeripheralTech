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
    public class DiscountController : BaseCRUDController<Model.Discount, DiscountSearchRequest, DiscountUpsertRequest, DiscountUpsertRequest>
    {
        public DiscountController(ICRUDService<Discount, DiscountSearchRequest, DiscountUpsertRequest, DiscountUpsertRequest> service) : base(service)
        {

        }
    }
}