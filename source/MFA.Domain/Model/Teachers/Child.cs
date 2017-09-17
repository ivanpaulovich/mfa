using MFA.Domain.Model.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFA.Domain.Model.Teachers
{
    public class Child : Entity
    {
        private Name name;

        public static Child Create()
        {
            return new Child();
        }
    }
}
