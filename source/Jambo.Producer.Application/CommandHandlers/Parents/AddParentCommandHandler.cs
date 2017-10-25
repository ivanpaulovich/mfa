using Jambo.Domain.Model.Schools;
using Jambo.Domain.Model.ValueTypes;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Parents;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Parents
{
    public class AddParentCommandHandler : IAsyncRequestHandler<AddParentCommand, Parent>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public AddParentCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task<Parent> Handle(AddParentCommand command)
        {
            School school = await schoolRepository.GetSchool(command.SchoolId);
            Parent parent = Parent.Create(
                Name.Create(command.Name), 
                Identification.Create(command.Identification),
                BirthDate.Create(command.BirthDate));
            
            school.AddParent(parent);

            await bus.Publish(school.GetEvents(), command.Header);

            return parent;
        }
    }
}
