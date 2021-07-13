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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Model.Order> Get([FromQuery]OrderSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Model.Order GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpGet("GetUnderReviewOrder")]
        public Model.Order GetUnderReviewOrder([FromQuery]OrderSearchRequest request)
        {
            return _service.GetUnderReviewOrder(request);
        }
        [HttpPost]
        public Model.Order Insert(OrderInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public Model.Order Update(int id, [FromBody]OrderUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}