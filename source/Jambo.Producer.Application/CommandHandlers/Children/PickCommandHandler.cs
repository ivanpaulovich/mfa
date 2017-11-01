using Jambo.Domain.Model.Schools;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Children;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Children
{
    public class PickCommandHandler : IAsyncRequestHandler<PickCommand>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public PickCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task Handle(PickCommand command)
        {
            School school = await schoolRepository.GetSchool(command.SchoolId);
            Parent parent = await schoolRepository.GetParent(command.SchoolId, command.Header.UserId);
            Child child = await schoolRepository.GetChild(command.SchoolId, command.ChildId);

            school.Pick(parent, child);

            await bus.Publish(school.GetEvents(), command.Header);
        }
    }
}
