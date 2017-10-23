using Jambo.Producer.Application.Commands.Parents;
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
    public class ParentsController : Controller
    {
        private readonly IMediator mediator;
        private readonly ISchoolQueries queries;

        public ParentsController(IMediator mediator, ISchoolQueries queries)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        //[HttpPatch("Create")]
        //public async Task<IActionResult> Create([FromBody]CreateCommand command)
        //{
        //    await mediator.Send(command);
        //    return (IActionResult)Ok();
        //}

        //[HttpPatch("Disable")]
        //public async Task<IActionResult> Disable([FromBody]DisableParentCommand command)
        //{
        //    await mediator.Send(command);
        //    return (IActionResult)Ok();
        //}

        //[HttpPatch("Enable")]
        //public async Task<IActionResult> Enable([FromBody]EnableCommand command)
        //{
        //    await mediator.Send(command);
        //    return (IActionResult)Ok();
        //}

        //[HttpPatch("UpdatePersonalDetails")]
        //public async Task<IActionResult> Enable([FromBody]UpdateParentPersonalDetailsCommand command)
        //{
        //    await mediator.Send(command);
        //    return (IActionResult)Ok();
        //}
    }
}
