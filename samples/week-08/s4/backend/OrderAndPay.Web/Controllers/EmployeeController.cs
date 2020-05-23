using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderAndPay.Web.Commands;
using OrderAndPay.Web.Models;

namespace OrderAndPay.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet("restaurants/{restaurantId}/menus")]
        public async Task<IActionResult> GetMenus(int restaurantId)
        {
            return Ok(InMemoryRepository.GetMenus(restaurantId));
        }

        [HttpGet("restaurants/{restaurantId}/menus/{menuId}")]
        public async Task<IActionResult> GetMenu(int restaurantId, int menuId)
        {
            return Ok(InMemoryRepository.GetMenuDetails(restaurantId, menuId));
        }

        [HttpPost("restaurants/{restaurantId}/menus/{menuId}/items")]
        public async Task<IActionResult> PostMenuItem(int restaurantId, int menuId, [Bind]CreateMenuItemCommand command)
        {
            return Ok(InMemoryRepository.CreateMenuItem(restaurantId, menuId, command));
        }
    }
}