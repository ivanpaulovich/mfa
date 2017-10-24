using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Jambo.Producer.Application.Queries;
using Jambo.Producer.Application.Commands.Parents;
using Jambo.Producer.Application.Commands.Teachers;

namespace Jambo.Producer.UI.Controllers
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

        [HttpPatch("Add")]
        public async Task<IActionResult> Create([FromBody] Application.Commands.Teachers.AddTeacherCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        //[HttpPatch("Disable")]
        //public async Task<IActionResult> Disable([FromBody]DisableTeacherCommand command)
        //{
        //    await mediator.Send(command);
        //    return (IActionResult)Ok();
        //}

        //[HttpPatch("Enable")]
        //public async Task<IActionResult> Enable([FromBody] Application.Commands.Teachers.EnableCommand command)
        //{
        //    await mediator.Send(command);
        //    return (IActionResult)Ok();
        //}
    }
}
