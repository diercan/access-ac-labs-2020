using System;
using Database.Context;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        protected readonly OrderAndPayContext _context;

        public BaseController(OrderAndPayContext context)
        {
            _context = context;
        }
    }
}