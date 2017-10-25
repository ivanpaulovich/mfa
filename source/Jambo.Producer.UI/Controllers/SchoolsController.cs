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
                SchoolId = createdSchool.Id,
                SchoolName = createdSchool.GetName().Text,
                ManagerId = createdSchool.GetManager().Id.ToString(),
                ManagerName = createdSchool.GetManager().GetName().ToString()
            };

            return CreatedAtRoute("GetSchoool", new { id = createdSchool.Id }, result);
        }

        [HttpGet(Name = "GetSchoool")]
        public async Task<IActionResult> Get(Guid schoolId)
        {
            var school = await queries.GetSchoolAsync(schoolId);

            return Ok(school);
        }

        [HttpGet("All")]
        public async Task<IActionResult> Get()
        {
            var schools = await queries.GetSchoolsAsync();

            return Ok(schools);
        }

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
