using Jambo.Domain.Model.Schools;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Children;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Teachers
{
    public class CheckInCommandHandler : IAsyncRequestHandler<CheckInCommand>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public CheckInCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task Handle(CheckInCommand command)
        {
            School school = await schoolRepository.GetSchool(command.SchoolId);
            Teacher teacher = await schoolRepository.GetTeacher(command.SchoolId, command.Header.UserId);
            Child child = await schoolRepository.GetChild(command.SchoolId, command.ChildId);

            school.CheckIn(teacher, child);

            await bus.Publish(school.GetEvents(), command.Header);
        }
    }
}
