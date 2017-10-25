using Jambo.Domain.Model.ValueTypes;
using System;

namespace Jambo.Domain.Model.Schools
{
    public class Child : Entity
    {
        private Name name;
        private BirthDate birthDate;
        private Custody currentCustody;

        public Name GetName()
        {
            return name;
        }

        public BirthDate GetBirthDate()
        {
            return birthDate;
        }

        public void Left()
        {
            currentCustody = Custody.Create(CustodyEnum.FamilyLeftChildAtSchool);
        }

        public void Pickup()
        {
            currentCustody = Custody.Create(CustodyEnum.FamilyPickeupChildAtSchool);
        }

        public void CheckIn()
        {
            currentCustody = Custody.Create(CustodyEnum.ChildConfirmedAtSchool);
        }

        public void CheckOut()
        {
            currentCustody = Custody.Create(CustodyEnum.TeacherCheckOutChildAtSchool);
        }

        private Child()
        {

        }

        public static Child Create(Name name, BirthDate birthDate, Custody currentCustody)
        {
            Child parent = new Child();
            parent.name = name;
            parent.birthDate = birthDate;
            parent.currentCustody = currentCustody;

            return parent;
        }

        public static Child Create(Guid id, Name name, BirthDate birthDate, Custody currentCustody)
        {
            Child parent = new Child();
            parent.Id = id;
            parent.name = name;
            parent.birthDate = birthDate;
            parent.currentCustody = currentCustody;

            return parent;
        }
    }
}
