using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFA.ServiceBus
{
    public interface ISubscriber : IDisposable
    {
        void Listen(IMediator mediator);
    }
}
