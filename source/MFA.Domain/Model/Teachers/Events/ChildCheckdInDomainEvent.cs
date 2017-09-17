using System;
using System.Collections.Generic;
using System.Text;

namespace MFA.Domain.Model.Teachers.Events
{
    public class ChildCheckdInDomainEvent : DomainEvent
    {
        public Guid ChildId { get; private set; }

        public ChildCheckdInDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Guid childId)
            : base(aggregateRootId, version, createdDate, header)
        {
            ChildId = childId;
        }

        public static ChildCheckdInDomainEvent Create(AggregateRoot aggregateRoot,
            Guid childId)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ChildCheckdInDomainEvent domainEvent = new ChildCheckdInDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, childId);

            return domainEvent;
        }
    }
}
