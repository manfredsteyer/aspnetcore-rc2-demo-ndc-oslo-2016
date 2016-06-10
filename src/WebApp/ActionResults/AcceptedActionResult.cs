using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummitDemo.ActionResults
{
    public class AcceptedActionResult : IActionResult
    {
        public Task ExecuteResultAsync(ActionContext context)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;

            response.StatusCode = 202; // Accepted
            response.Headers.Add("X-Ref", "4711");

            //response.Body.WriteByte(65);

            return Task.FromResult<object>(null);
        }
    }
}
