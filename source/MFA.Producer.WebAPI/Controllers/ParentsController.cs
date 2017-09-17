using MFA.Producer.Application.Commands.Parents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MFA.Producer.Application.Queries;

namespace MFA.Producer.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ParentsController : Controller
    {
        private readonly IMediator mediator;
        private readonly ISchoolQueries queries;

        public ParentsController(IMediator mediator, ISchoolQueries queries)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        [HttpPatch("LeaveChildIn")]
        public async Task<IActionResult> Enable([FromBody]LeaveChildInCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("PickChildUp")]
        public async Task<IActionResult> Enable([FromBody]PickChildCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }
    }
}
