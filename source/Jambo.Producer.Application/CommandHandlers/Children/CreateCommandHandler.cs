using Jambo.Domain.Model.Schools;
using Jambo.Domain.Model.ValueTypes;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Children;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Children
{
    public class CreateCommandHandler : IAsyncRequestHandler<CreateCommand, Guid>
    {
        private readonly IPublisher bus;
        private readonly ISchoolReadOnlyRepository schoolRepository;

        public CreateCommandHandler(IPublisher bus, ISchoolReadOnlyRepository schoolRepository)
        {
            this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
            this.schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        public async Task<Guid> Handle(CreateCommand command)
        {
            School school = await schoolRepository.GetSchoolByTeacherId(command.Header.UserId);
            Parent parent = await schoolRepository.GetParentById(command.ParentId);

            Child child = Child.Create(
                Name.Create(command.Name), 
                BirthDate.Create(command.BirthDate));

            school.AddChild(parent, child);

            await bus.Publish(school.GetEvents(), command.Header);

            return school.Id;
        }
    }
}
