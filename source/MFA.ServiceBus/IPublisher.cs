using MFA.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MFA.ServiceBus
{
    public interface IPublisher : IDisposable
    {
        Task Publish(DomainEvent domainEvent);
        Task Publish(IEnumerable<DomainEvent> domainEvents, Header header);
    }
}
