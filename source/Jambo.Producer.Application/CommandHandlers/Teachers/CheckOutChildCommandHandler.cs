using MediatR;
using Jambo.Domain.Model.Schools;
using Jambo.Producer.Application.Commands.Teachers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Children;

namespace Jambo.Producer.Application.CommandHandlers.Teachers
{
    public class CheckOutChildCommandHandler : IAsyncRequestHandler<CheckOutChildCommand, Guid>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public CheckOutChildCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task<Guid> Handle(CheckOutChildCommand command)
        {
            School school = await schoolRepository.GetSchoolByChildId(command.ChildId);
            school.LeaveChild(command.ChildId);

            await bus.Publish(school.GetEvents(), command.Header);

            return school.Id;
        }
    }
}
