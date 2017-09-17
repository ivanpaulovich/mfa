using System;

namespace MFA.Domain.Model
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
