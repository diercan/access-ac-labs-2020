using System;
using System.Linq;
using System.Threading.Tasks;
using Database.Abstractions;
using Database.Context;
using Database.Entities;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class ExempleController : BaseController
    {
        public ExempleController(OrderAndPayContext context, LiveInterpreterAsync interpreter) : base(context, interpreter)
        {
        }
        
        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var crudeResult = Database.Database.Get<RestaurantEntity>(a => true);
            var res = await Interpreter.Interpret(crudeResult, Unit.Default);
            var result = res.Match(
                a => (IActionResult)Ok(a.Items), 
                a => NotFound(a.Reason.ToString()));
            return result;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetRestaurant([FromRoute] string name)
        {
            var crudeResult = Database.Database.Get<RestaurantEntity>(a => 
                string.Equals(a.Name, name, StringComparison.CurrentCultureIgnoreCase));
            var res = await Interpreter.Interpret(crudeResult, Unit.Default);
            var result = res.Match(
                a => (IActionResult)Ok(a.Items.FirstOrDefault()),
                a => NotFound(a.Reason.ToString()));
            return result;
        }
    }
}