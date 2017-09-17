using System;

namespace MFA.Domain.Model.Schools.Events
{
    public class ChildLeftInDomainEvent : DomainEvent
    {
        public Guid ChildId { get; private set; }

        public ChildLeftInDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Guid childId)
            : base(aggregateRootId, version, createdDate, header)
        {
            ChildId = childId;
        }

        public static ChildLeftInDomainEvent Create(AggregateRoot aggregateRoot,
            Guid childId)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ChildLeftInDomainEvent domainEvent = new ChildLeftInDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, childId);

            return domainEvent;
        }
    }
}
