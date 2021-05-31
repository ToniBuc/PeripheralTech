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
    public class OrderController : BaseCRUDController<Model.Order, OrderSearchRequest, OrderInsertRequest, OrderUpdateRequest>
    {
        public OrderController(ICRUDService<Order, OrderSearchRequest, OrderInsertRequest, OrderUpdateRequest> service) : base(service)
        {

        }
    }
}