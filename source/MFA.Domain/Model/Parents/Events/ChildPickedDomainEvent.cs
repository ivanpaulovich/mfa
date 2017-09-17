using System;

namespace MFA.Domain.Model.Parents.Events
{
    public class ChildPickedDomainEvent : DomainEvent
    {
        public Guid ChildId { get; private set; }

        public ChildPickedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Guid childId)
            : base(aggregateRootId, version, createdDate, header)
        {
            ChildId = childId;
        }

        public static ChildPickedDomainEvent Create(AggregateRoot aggregateRoot,
            Guid childId)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ChildPickedDomainEvent domainEvent = new ChildPickedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, childId);

            return domainEvent;
        }
    }
}
