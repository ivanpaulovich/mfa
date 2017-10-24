using Jambo.Domain.Model.ValueTypes;
using System;

namespace Jambo.Domain.Model.Schools
{
    public class Child : Entity
    {
        private Name name;
        private BirthDate birthDate;

        public Name GetName()
        {
            return name;
        }

        public BirthDate GetBirthDate()
        {
            return birthDate;
        }

        private Child()
        {

        }

        public static Child Create(Name name, BirthDate birthDate)
        {
            Child parent = new Child();
            parent.name = name;
            parent.birthDate = birthDate;

            return parent;
        }

        public static Child Create(Guid id, Name name, BirthDate birthDate)
        {
            Child parent = new Child();
            parent.Id = id;
            parent.name = name;
            parent.birthDate = birthDate;

            return parent;
        }
    }
}
