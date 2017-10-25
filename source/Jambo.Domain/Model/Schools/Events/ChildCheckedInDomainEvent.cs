using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Model.Schools.Events
{
    public class ChildCheckedInDomainEvent : DomainEvent
    {
        public Guid ChildId { get; private set; }

        public ChildCheckedInDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Guid childId)
            : base(aggregateRootId, version, createdDate, header)
        {
            ChildId = childId;
        }

        public static ChildCheckedInDomainEvent Create(AggregateRoot aggregateRoot,
            Guid childId)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ChildCheckedInDomainEvent domainEvent = new ChildCheckedInDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, childId);

            return domainEvent;
        }
    }
}
