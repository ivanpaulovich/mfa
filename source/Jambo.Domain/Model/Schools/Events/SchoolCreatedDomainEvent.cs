using Jambo.Domain.Model.ValueTypes;
using System;

namespace Jambo.Domain.Model.Schools.Events
{
    public class SchoolCreatedDomainEvent : DomainEvent
    {
        public Name SchoolName { get; private set; }
        public Guid ManagerId { get; private set; }
        public Name ManagerName { get; private set; }

        public SchoolCreatedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Name schoolName, Guid managerId, Name managerName)
            : base(aggregateRootId, version, createdDate, header)
        {
            SchoolName = schoolName;
            ManagerId = managerId;
            ManagerName = managerName;
        }

        public static SchoolCreatedDomainEvent Create(AggregateRoot aggregateRoot,
            Name schoolName, Guid managerId, Name managerName)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            SchoolCreatedDomainEvent domainEvent = new SchoolCreatedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null,
                schoolName, managerId, managerName);

            return domainEvent;
        }
    }
}
