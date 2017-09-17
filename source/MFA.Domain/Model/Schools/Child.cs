using MFA.Domain.Model.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFA.Domain.Model.Schools
{
    public class Child : Entity
    {
        private Name name;

        private Child()
        {

        }

        public static Child Create()
        {
            return new Child();
        }
    }
}
