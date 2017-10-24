using Jambo.Domain.Model;
using Jambo.Producer.Application.Commands;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Jambo.Producer.UI.Filters
{
    public class SchoolFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ClaimsIdentity identity = context.HttpContext.User.Identity as ClaimsIdentity;

            if (identity.IsAuthenticated)
            {
                string groupSid = identity
                    .Claims
                    .Where(e => e.Type == ClaimTypes.GroupSid)
                    .FirstOrDefault().Value.ToString();

                context.ActionArguments["schoolId"] = new Guid(groupSid);
            }
        }
    }
}
