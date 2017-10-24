using Jambo.Domain.Model;
using Jambo.Producer.Application.Commands;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Jambo.Producer.UI.Filters
{
    public class CorrelationFilter : ActionFilterAttribute
    {
        private Guid correlationId;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.ContainsKey("command"))
                return;

            CommandBase command = context.ActionArguments["command"] as CommandBase;

            if (command == null)
                return;

            if (context.HttpContext.Request.Headers.ContainsKey("correlationid"))
                correlationId = Guid.Parse(context.HttpContext.Request.Headers["correlationid"]);
            else
                correlationId = Guid.NewGuid();

            ClaimsIdentity identity = context.HttpContext.User.Identity as ClaimsIdentity;

            if (identity.IsAuthenticated)
            {
                string userId = identity
                    .Claims
                    .Where(e => e.Type == JwtRegisteredClaimNames.Jti)
                    .FirstOrDefault().Value.ToString();

                string userName = identity
                    .Claims
                    .Where(e => e.Type == ClaimTypes.NameIdentifier)
                    .FirstOrDefault().Value.ToString();

                string groupSid = identity
                    .Claims
                    .Where(e => e.Type == ClaimTypes.GroupSid)
                    .FirstOrDefault().Value.ToString();

                context.ActionArguments["schoolId"] = groupSid;

                command.Header = Header.Create(correlationId, new Guid(userId), userName);
            }
            else
            {
                command.Header = Header.Create(correlationId);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            context.HttpContext.Response.Headers.Add("correlationid", correlationId.ToString());
        }
    }
}
