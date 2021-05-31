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
    public class UserRoleController : BaseController<Model.UserRole, object>
    {
        public UserRoleController(IService<UserRole, object> service) : base(service)
        {

        }
    }
}