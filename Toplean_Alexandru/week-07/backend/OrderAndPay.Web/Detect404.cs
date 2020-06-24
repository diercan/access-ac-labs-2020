using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndPay.Web
{
    public class Detect404
    {
        private readonly RequestDelegate _next;

        public Detect404(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
            if (httpContext.Response.StatusCode == 404)
            {
                // To be replaced with the actual 404 Error Page
                httpContext.Response.Redirect("api/employee/restaurant/McDonalds");
            }
        }
    }
}