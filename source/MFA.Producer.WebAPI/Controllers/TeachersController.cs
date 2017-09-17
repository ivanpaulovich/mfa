using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using MFA.Producer.Application.Queries;
using MFA.Producer.Application.Commands.Parents;
using MFA.Producer.Application.Commands.Teachers;

namespace MFA.Producer.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TeachersController : Controller
    {
        private readonly IMediator mediator;
        private readonly ISchoolQueries queries;

        public TeachersController(IMediator mediator, ISchoolQueries queries)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        [HttpPatch("LeaveChildIn")]
        public async Task<IActionResult> Enable([FromBody]CheckInChildCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("PickChildUp")]
        public async Task<IActionResult> Enable([FromBody]CheckOutChildCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }
    }
}
