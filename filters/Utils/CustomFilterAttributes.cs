using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace filters.Utils
{
    public class CustomFilterAttributes : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) 
        {
            var result = context.Result; 
            if (result is PageResult)
            { 
                var page = ((PageResult)result); 
                page.ViewData["ip"] = context.HttpContext.Connection.RemoteIpAddress;
            }
            await next();
        }
    }
}
