using System;

namespace Jambo.Domain.Model.Schools.Events
{
    public class ChildPickedUpDomainEvent : DomainEvent
    {
        public Guid ChildId { get; private set; }

        public ChildPickedUpDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Guid childId)
            : base(aggregateRootId, version, createdDate, header)
        {
            ChildId = childId;
        }

        public static ChildPickedUpDomainEvent Create(AggregateRoot aggregateRoot,
            Guid childId)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ChildPickedUpDomainEvent domainEvent = new ChildPickedUpDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, childId);

            return domainEvent;
        }
    }
}
