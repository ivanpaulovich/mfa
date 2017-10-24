using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Jambo.Producer.Application.Queries;
using Jambo.Domain.Model.Schools;

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
        public async Task<IActionResult> Add([FromBody] Application.Commands.Teachers.AddTeacherCommand command)
        {
            Teacher teacher = await mediator.Send(command);

            var result = new
            {
                TeacherId = teacher.Id,
                Name = teacher.GetName().Text,
            };

            return CreatedAtRoute("GetTeacher", 
                new { id = teacher.Id, schoolId = command.SchoolId }, 
                result);
        }

        [HttpGet("{id}", Name = "GetTeacher")]
        public async Task<IActionResult> Get(Guid schoolId, Guid id)
        {
            var teacher = await queries.GetTeacherAsync(schoolId, id);

            return Ok(teacher);
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
