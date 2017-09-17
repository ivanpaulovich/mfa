using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MFA.Domain.Model.Parents
{
    interface IParentWriteOnlyRepository
    {
        Task AddParent(Parent parent);
        Task UpdateParentg(Parent parent);
    }
}
