using Jambo.Producer.Application.Commands.Children;
using Jambo.Producer.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.UI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ChildrenController : Controller
    {
        private readonly IMediator mediator;
        private readonly ISchoolQueries queries;

        public ChildrenController(IMediator mediator, ISchoolQueries queries)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        [HttpPatch("CheckIn")]
        public async Task<IActionResult> CheckIn([FromBody]CheckInChildCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("CheckOut")]
        public async Task<IActionResult> CheckOut([FromBody]CheckOutChildCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("Create")]
        public async Task<IActionResult> Create([FromBody]CreateChildCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("LeaveIn")]
        public async Task<IActionResult> Leave([FromBody]LeaveChildInCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("Pick")]
        public async Task<IActionResult> Pick([FromBody]PickChildCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }
    }
}
