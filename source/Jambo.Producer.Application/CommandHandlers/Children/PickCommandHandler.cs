using Jambo.Domain.Model.Schools;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Children;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Children
{
    public class PickCommandHandler : IAsyncRequestHandler<CheckOutCommand, Guid>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public PickCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task<Guid> Handle(CheckOutCommand command)
        {
            School school = await schoolRepository.GetSchoolByTeacherId(command.Header.UserId);
            Child child = await schoolRepository.GetChildById(command.ChildId);
            school.PickChild(command.ChildId);

            await bus.Publish(school.GetEvents(), command.Header);

            return school.Id;
        }
    }
}
