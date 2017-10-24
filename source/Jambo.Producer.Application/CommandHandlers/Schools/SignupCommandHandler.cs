using Jambo.Domain.Model.Schools;
using Jambo.Domain.Model.ValueTypes;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Schools;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Schools
{
    public class SignupCommandHandler : IAsyncRequestHandler<SignupCommand, School>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public SignupCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task<School> Handle(SignupCommand command)
        {
            School school = School.Create(Name.Create(command.SchoolName));
            Teacher teacher = Teacher.Create(Name.Create(command.ManagerName));

            command.Header = new Domain.Model.Header(
                command.Header.CorrelationId,
                teacher.Id,
                teacher.GetName().ToString());

            school.CreateWithManager(teacher);

            await bus.Publish(school.GetEvents(), command.Header);
            return school;
        }
    }
}
