using System;
using System.Collections.Generic;
using System.Text;

namespace MFA.Domain.Model.Schools.Events
{
    public class ChildCheckdOutDomainEvent : DomainEvent
    {
        public Guid ChildId { get; private set; }

        public ChildCheckdOutDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Guid childId)
            : base(aggregateRootId, version, createdDate, header)
        {
            ChildId = childId;
        }

        public static ChildCheckdOutDomainEvent Create(AggregateRoot aggregateRoot,
            Guid childId)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ChildCheckdOutDomainEvent domainEvent = new ChildCheckdOutDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, childId);

            return domainEvent;
        }
    }
}
