using Jambo.Domain.Model.ValueTypes;
using System.Collections.Generic;
using System;

namespace Jambo.Domain.Model.Schools
{
    public class Parent : Entity
    {
        private Name name;
        private Identification identification;
        private BirthDate birthDate;
        private List<Child> children;

        public Name GetName()
        {
            return name;
        }

        public Identification GetIdentification()
        {
            return identification;
        }

        public BirthDate GetBirthDate()
        {
            return birthDate;
        }

        private Parent()
        {

        }

        public static Parent Create(Name name, Identification identification, BirthDate birthDate)
        {
            Parent parent = new Parent();
            parent.name = name;
            parent.identification = identification;
            parent.birthDate = birthDate;

            return parent;
        }

        public static Parent Create(Guid id, Name name, Identification identification, BirthDate birthDate)
        {
            Parent parent = new Parent();
            parent.Id = id;
            parent.name = name;
            parent.identification = identification;
            parent.birthDate = birthDate;

            return parent;
        }

        public void AddChild(Child child)
        {
            children = children ?? new List<Child>();
            children.Add(child);
        }
    }
}
