using Jambo.Producer.Application.Commands.Parents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Jambo.Producer.Application.Queries;
using Jambo.Producer.Application.Commands.Schools;
using Jambo.Domain.Model.Schools;

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

        [AllowAnonymous]
        [HttpPatch("Signup")]
        public async Task<IActionResult> Signup([FromBody] Application.Commands.Schools.SignupCommand command)
        {
            School createdSchool = await mediator.Send<School>(command);

            var result = new
            {
                ManagerId = createdSchool.GetManager().Id.ToString(),
                ManagerName = createdSchool.GetManager().GetName().ToString()
            };

            return CreatedAtRoute("GetSchoool", new { id = createdSchool.Id }, result);
        }

        [HttpGet("{id}", Name = "GetSchoool")]
        public async Task<IActionResult> Get(Guid id)
        {
            var school = await queries.GetSchoolAsync(id);

            return Ok(school);
        }

        //[HttpPatch("Create")]
        //public async Task<IActionResult> Create([FromBody] Application.Commands.Schools.CreateCommand command)
        //{
        //    await mediator.Send(command);
        //    return (IActionResult)Ok();
        //}

        //[HttpPatch("Disable")]
        //public async Task<IActionResult> Disable([FromBody]DisableSchoolCommand command)
        //{
        //    await mediator.Send(command);
        //    return (IActionResult)Ok();
        //}

        //[HttpPatch("Enable")]
        //public async Task<IActionResult> Enable([FromBody] Application.Commands.Schools.EnableCommand command)
        //{
        //    await mediator.Send(command);
        //    return (IActionResult)Ok();
        //}

        //[HttpPatch("UpdateDetails")]
        //public async Task<IActionResult> UpdateDetails([FromBody]UpdateSchoolDetailsCommand command)
        //{
        //    await mediator.Send(command);
        //    return (IActionResult)Ok();
        //}
    }
}
