using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFA.Domain.Model.Parents
{
    interface IParentReadOnlyRepository
    {
        Task<IEnumerable<Parent>> GetAllParents();
        Task<Parent> GetParent(Guid id);
    }
}
