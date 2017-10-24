using Jambo.Domain.Model.Schools;
using Jambo.Domain.Model.Schools.Events;
using MediatR;
using System;

namespace Jambo.Consumer.Application.DomainEventHandlers.Schools
{
    public class SchoolCreatedDomainEventDomainEventHandler : IRequestHandler<SchoolCreatedDomainEvent>
    {
        private readonly ISchoolReadOnlyRepository schoolReadOnlyRepository;
        private readonly ISchoolWriteOnlyRepository schoolWriteOnlyRepository;

        public SchoolCreatedDomainEventDomainEventHandler(
            ISchoolReadOnlyRepository schoolReadOnlyRepository,
            ISchoolWriteOnlyRepository schoolWriteOnlyRepository)
        {
            this.schoolReadOnlyRepository = schoolReadOnlyRepository ??
                throw new ArgumentNullException(nameof(schoolReadOnlyRepository));
            this.schoolWriteOnlyRepository = schoolWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(schoolWriteOnlyRepository));
        }

        public void Handle(SchoolCreatedDomainEvent domainEvent)
        {
            School school = School.Create();
            school.Apply(domainEvent);
            schoolWriteOnlyRepository.AddSchool(school).Wait();
        }
    }
}
