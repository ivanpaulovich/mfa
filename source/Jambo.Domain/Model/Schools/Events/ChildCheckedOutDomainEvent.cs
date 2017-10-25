using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Model.Schools.Events
{
    public class ChildCheckedOutDomainEvent : DomainEvent
    {
        public Guid ChildId { get; private set; }

        public ChildCheckedOutDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Guid childId)
            : base(aggregateRootId, version, createdDate, header)
        {
            ChildId = childId;
        }

        public static ChildCheckedOutDomainEvent Create(AggregateRoot aggregateRoot,
            Guid childId)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ChildCheckedOutDomainEvent domainEvent = new ChildCheckedOutDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, childId);

            return domainEvent;
        }
    }
}
