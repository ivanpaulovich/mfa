using Jambo.Domain.Model.ValueTypes;
using System;

namespace Jambo.Domain.Model.Schools.Events
{
    public class TeacherAddedDomainEvent : DomainEvent
    {
        public Guid TeacherId { get; private set; }
        public Name TeacherName { get; private set; }

        public TeacherAddedDomainEvent(Guid aggregateRootId, int version,
            DateTime createdDate, Header header, Guid teacherId, Name teacherName)
            : base(aggregateRootId, version, createdDate, header)
        {
            TeacherId = teacherId;
            TeacherName = teacherName;
        }

        public static TeacherAddedDomainEvent Create(AggregateRoot aggregateRoot,
            Guid teacherId, Name teacherName)
        {
            if (aggregateRoot == null)
                throw new ArgumentNullException("aggregateRoot");

            TeacherAddedDomainEvent domainEvent = new TeacherAddedDomainEvent(
                aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null,
                teacherId, teacherName);

            return domainEvent;
        }
    }
}
