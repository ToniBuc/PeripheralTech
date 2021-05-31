using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeripheralTech.Model;
using PeripheralTech.WebAPI.Services;

namespace PeripheralTech.WebAPI.Controllers
{
    public class OrderStatusController : BaseController<Model.OrderStatus, object>
    {
        public OrderStatusController(IService<OrderStatus, object> service) : base(service)
        {

        }
    }
}