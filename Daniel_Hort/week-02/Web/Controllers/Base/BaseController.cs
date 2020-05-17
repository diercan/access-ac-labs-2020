using System;
using Database.Context;
using Infrastructure.Free;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        protected readonly OrderAndPayContext Context;
        protected readonly LiveInterpreterAsync Interpreter;

        public BaseController(OrderAndPayContext context, LiveInterpreterAsync interpreter)
        {
            Context = context;
            Interpreter = interpreter;
        }
    }
}