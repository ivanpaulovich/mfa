using Jambo.Domain.Model.Schools;
using Jambo.Domain.Model.ValueTypes;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Application.Commands.Schools;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Schools
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
            School school = School.Create(Name.Create(command.Title));
            Teacher teacher = await schoolRepository.GetTeacherById(command.Header.UserId);

            school.CreateWithManager(teacher);
            
            await bus.Publish(school.GetEvents(), command.Header);
            return school.Id;
        }
    }
}
