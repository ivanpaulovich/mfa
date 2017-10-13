using MediatR;
using Jambo.Domain.Model.Schools;
using Jambo.Producer.Application.Commands.Parents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jambo.Domain.ServiceBus;

namespace Jambo.Producer.Application.CommandHandlers.Parents
{
    public class LeaveChildInCommandHandler : IAsyncRequestHandler<LeaveChildInCommand, Guid>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public LeaveChildInCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task<Guid> Handle(LeaveChildInCommand command)
        {
            School school = await schoolRepository.GetSchool(command.SchoolId);
            school.LeaveChild(command.ChildId);

            await bus.Publish(school.GetEvents(), command.Header);

            return school.Id;
        }
    }
}
