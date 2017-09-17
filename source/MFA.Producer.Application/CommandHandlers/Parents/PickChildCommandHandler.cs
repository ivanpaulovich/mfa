using MediatR;
using MFA.Domain.Model.Schools;
using MFA.Producer.Application.Commands.Parents;
using MFA.Producer.Application.Commands.Teachers;
using MFA.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MFA.Producer.Application.CommandHandlers.Parents
{
    public class PickChildCommandHandler : IAsyncRequestHandler<CheckOutChildCommand, Guid>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public PickChildCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task<Guid> Handle(CheckOutChildCommand command)
        {
            School school = await schoolRepository.GetSchool(command.SchoolId);
            school.LeaveChild(command.ChildId);

            await bus.Publish(school.GetEvents(), command.Header);

            return school.Id;
        }
    }
}
