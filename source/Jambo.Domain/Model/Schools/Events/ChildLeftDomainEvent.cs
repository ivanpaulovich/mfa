using System;

namespace Jambo.Domain.Model.Schools.Events
{
    public class ChildLeftDomainEvent : DomainEvent
    {
        public Guid ChildId { get; private set; }

        public ChildLeftDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Guid childId)
            : base(aggregateRootId, version, createdDate, header)
        {
            ChildId = childId;
        }

        public static ChildLeftDomainEvent Create(AggregateRoot aggregateRoot,
            Guid childId)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ChildLeftDomainEvent domainEvent = new ChildLeftDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, childId);

            return domainEvent;
        }
    }
}
