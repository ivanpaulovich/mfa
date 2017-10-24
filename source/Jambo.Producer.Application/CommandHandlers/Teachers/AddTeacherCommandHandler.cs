using Jambo.Domain.Model.Schools;
using Jambo.Domain.Model.ValueTypes;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Teachers;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Teachers
{
    public class AddTeacherCommandHandler : IAsyncRequestHandler<AddTeacherCommand, Teacher>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public AddTeacherCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task<Teacher> Handle(AddTeacherCommand command)
        {
            School school = await schoolRepository.GetSchool(command.SchoolId);
            Teacher teacher = Teacher.Create(Name.Create(command.Name));

            school.AddTeacher(teacher);

            await bus.Publish(school.GetEvents(), command.Header);
            return teacher;
        }
    }
}
