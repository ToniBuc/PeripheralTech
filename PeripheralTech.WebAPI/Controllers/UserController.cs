using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeripheralTech.Model.Requests;
using PeripheralTech.WebAPI.Services;

namespace PeripheralTech.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.User> Get([FromQuery]UserSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{id}")]
        public Model.User GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpGet("GetStaff")]
        public List<Model.User> GetStaff([FromQuery]UserSearchRequest request)
        {
            return _service.GetStaff(request);
        }
        [HttpPost]
        public Model.User Insert(UserInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public Model.User Update(int id, [FromBody]UserUpdateRequest request)
        {
            return _service.Update(id, request);
        }
        [HttpPost("Login")]
        public Model.User Login(UserLoginRequest request)
        {
            return _service.Login(request);
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public Model.User Register(UserInsertRequest request)
        {
            return _service.Register(request);
        }
    }
}