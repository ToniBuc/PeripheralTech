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
    public class OrderProductController : BaseCRUDController<Model.OrderProduct, OrderProductSearchRequest, OrderProductUpsertRequest, OrderProductUpsertRequest>
    {
        public OrderProductController(ICRUDService<OrderProduct, OrderProductSearchRequest, OrderProductUpsertRequest, OrderProductUpsertRequest> service) : base(service)
        {

        }
    }
}