using System;
using Microsoft.AspNetCore.Mvc.Filters;
using TechnicalRadiation.Models.Exceptions;

namespace TechnicalRadiation.WebApi.Attributes
{
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        private readonly string authorizationToken = "14|_|7|-|0|21Z3";
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Request.Headers["Authorization"] != authorizationToken) 
            {
                throw new AuthorizationException("You are currently unauthorized");
            }
        }
    }
}