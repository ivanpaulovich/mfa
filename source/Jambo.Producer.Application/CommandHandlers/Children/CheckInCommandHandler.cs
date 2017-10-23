using Jambo.Domain.Model.Schools;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Children;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Teachers
{
    public class CheckInCommandHandler : IAsyncRequestHandler<CheckInCommand, Guid>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public CheckInCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task<Guid> Handle(CheckInCommand command)
        {
            School school = await schoolRepository.GetSchoolByChildId(command.ChildId);
            Parent parent = await schoolRepository.GetParentById(command.Header.UserId);
            Child child = await schoolRepository.GetChildById(command.ChildId);

            school.CheckIn(parent, child);

            await bus.Publish(school.GetEvents(), command.Header);

            return school.Id;
        }
    }
}
