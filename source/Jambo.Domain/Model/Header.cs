using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Model
{
    public class Header
    {
        public Guid CorrelationId { get; private set; }
        public Guid UserId { get; private set; }
        public string UserName { get; private set; }

        public Header(Guid correlationId)
        {
            this.CorrelationId = correlationId;
        }

        public Header(Guid correlationId, Guid userId, string userName)
        {
            this.CorrelationId = correlationId;
            this.UserId = userId;
            this.UserName = userName;
        }
    }
}
