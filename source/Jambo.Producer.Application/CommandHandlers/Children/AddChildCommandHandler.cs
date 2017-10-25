using Jambo.Domain.Model.Schools;
using Jambo.Domain.Model.ValueTypes;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Children;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Children
{
    public class AddChildCommandHandler : IAsyncRequestHandler<AddChildCommand, Child>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public AddChildCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task<Child> Handle(AddChildCommand command)
        {
            School school = await schoolRepository.GetSchool(command.SchoolId);
            Parent parent = await schoolRepository.GetParent(command.SchoolId, command.ParentId);

            Child child = Child.Create(
                Name.Create(command.Name), 
                BirthDate.Create(command.BirthDate));

            school.AddChild(parent, child);

            await bus.Publish(school.GetEvents(), command.Header);

            return child;
        }
    }
}
