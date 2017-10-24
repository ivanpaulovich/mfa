using Jambo.Domain.Model.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Model.Schools
{
    public class Child : Entity
    {
        private Name name;
        private BirthDate birthDate;

        private Child()
        {

        }

        public static Child Create()
        {
            return new Child();
        }

        public static Child Create(Name name, BirthDate birthDate)
        {
            throw new NotImplementedException();
        }
    }
}
