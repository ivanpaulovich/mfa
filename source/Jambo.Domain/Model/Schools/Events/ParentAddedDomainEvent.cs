using Jambo.Domain.Model.ValueTypes;
using System;

namespace Jambo.Domain.Model.Schools.Events
{
    public class ParentAddedDomainEvent : DomainEvent
    {
        public Guid ParentId { get; private set; }
        public Name Name { get; private set; }
        public Identification Identification { get; private set; }
        public BirthDate BirthDate { get; private set; }

        public ParentAddedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header,
            Guid parentId, Name name, Identification identification, BirthDate birthDate)
            : base(aggregateRootId, version, createdDate, header)
        {
            ParentId = parentId;
            Name = name;
            Identification = identification;
            BirthDate = birthDate;
        }

        public static ParentAddedDomainEvent Create(AggregateRoot aggregateRoot,
            Guid parentId, Name name, Identification identification, BirthDate birthDate)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            ParentAddedDomainEvent domainEvent = new ParentAddedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null,
                parentId, name, identification, birthDate);

            return domainEvent;
        }
    }
}
