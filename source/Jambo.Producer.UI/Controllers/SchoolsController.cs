using Jambo.Producer.Application.Commands.Parents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Jambo.Producer.Application.Queries;
using Jambo.Producer.Application.Commands.Schools;

namespace Jambo.Producer.UI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SchoolsController : Controller
    {
        private readonly IMediator mediator;
        private readonly ISchoolQueries queries;

        public SchoolsController(IMediator mediator, ISchoolQueries queries)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        [HttpPatch("Create")]
        public async Task<IActionResult> Create([FromBody]CreateSchoolCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("Disable")]
        public async Task<IActionResult> Disable([FromBody]DisableSchoolCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("Enable")]
        public async Task<IActionResult> Enable([FromBody]EnableSchoolCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("UpdateDetails")]
        public async Task<IActionResult> UpdateDetails([FromBody]UpdateSchoolDetailsCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }
    }
}
