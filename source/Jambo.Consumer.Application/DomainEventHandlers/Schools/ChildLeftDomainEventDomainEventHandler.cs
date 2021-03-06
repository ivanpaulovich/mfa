﻿using Jambo.Domain.Exceptions;
using Jambo.Domain.Model.Schools;
using Jambo.Domain.Model.Schools.Events;
using MediatR;
using System;

namespace Jambo.Consumer.Application.DomainEventHandlers.Schools
{
    public class ChildLeftDomainEventDomainEventHandler : IRequestHandler<ChildLeftDomainEvent>
    {
        private readonly ISchoolReadOnlyRepository schoolReadOnlyRepository;
        private readonly ISchoolWriteOnlyRepository schoolWriteOnlyRepository;

        public ChildLeftDomainEventDomainEventHandler(
            ISchoolReadOnlyRepository schoolReadOnlyRepository,
            ISchoolWriteOnlyRepository schoolWriteOnlyRepository)
        {
            this.schoolReadOnlyRepository = schoolReadOnlyRepository ??
                throw new ArgumentNullException(nameof(schoolReadOnlyRepository));
            this.schoolWriteOnlyRepository = schoolWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(schoolWriteOnlyRepository));
        }

        public void Handle(ChildLeftDomainEvent domainEvent)
        {
            School school = schoolReadOnlyRepository.GetSchool(domainEvent.AggregateRootId).Result;

            if (school.Version != domainEvent.Version)
                throw new TransactionConflictException(school, domainEvent);

            school.Apply(domainEvent);
            schoolWriteOnlyRepository.UpdateSchool(school).Wait();
        }
    }
}
