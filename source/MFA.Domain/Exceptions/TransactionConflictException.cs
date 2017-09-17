using MFA.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFA.Domain.Exceptions
{
    public class TransactionConflictException : MFAException
    {
        public AggregateRoot AggregateRoot { get; private set; }
        public DomainEvent DomainEvent { get; private set; }

        public TransactionConflictException(AggregateRoot aggregateRoot, DomainEvent domainEvent)
        {
            this.AggregateRoot = aggregateRoot;
            this.DomainEvent = domainEvent;
        }
    }
}
