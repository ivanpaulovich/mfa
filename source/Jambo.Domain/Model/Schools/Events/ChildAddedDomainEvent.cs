using Jambo.Domain.Model.ValueTypes;
using System;

namespace Jambo.Domain.Model.Schools.Events
{
    public class ChildAddedDomainEvent : DomainEvent
    {
        public Guid ParentId { get; private set; }
        public Guid ChildId { get; private set; }
        public Name Name { get; private set; }
        public BirthDate BirthDate { get; private set; }

        public ChildAddedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header,
            Guid parentId, Guid childId, Name name, BirthDate birthDate)
            : base(aggregateRootId, version, createdDate, header)
        {
            ParentId = parentId;
            ChildId = childId;
            Name = name;
            BirthDate = birthDate;
        }

        public static ChildAddedDomainEvent Create(AggregateRoot aggregateRoot,
            Guid parentId, Guid childId, Name name, BirthDate birthDate)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ChildAddedDomainEvent domainEvent = new ChildAddedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null,
                parentId, childId, name, birthDate);

            return domainEvent;
        }
    }
}
