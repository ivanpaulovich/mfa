using MediatR;
using Jambo.Domain.Model.Schools;
using Jambo.Producer.Application.Commands.Parents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Children;

namespace Jambo.Producer.Application.CommandHandlers.Children
{
    public class LeaveCommandHandler : IAsyncRequestHandler<LeaveInCommand>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public LeaveCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task Handle(LeaveInCommand command)
        {
            School school = await schoolRepository.GetSchool(command.SchooId);
            Parent parent = await schoolRepository.GetParent(command.SchooId, command.Header.UserId);
            Child child = await schoolRepository.GetChild(command.SchooId, command.ChildId);

            school.Leave(parent, child);

            await bus.Publish(school.GetEvents(), command.Header);
        }
    }
}
