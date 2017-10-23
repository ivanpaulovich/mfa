using Jambo.Domain.Model.ValueTypes;
using System.Collections.Generic;
using System;

namespace Jambo.Domain.Model.Schools
{
    public class Parent : Entity
    {
        private Name name;
        private List<Child> children;

        private Parent()
        {

        }

        public static Parent Create()
        {
            return new Parent();
        }

        public static Parent Create(Name name, Identification identification, BirthDate birthDate)
        {
            throw new NotImplementedException();
        }
    }
}
