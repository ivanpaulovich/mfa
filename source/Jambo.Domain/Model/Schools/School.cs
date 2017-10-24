using Jambo.Domain.Model.Schools.Events;
using Jambo.Domain.Model.ValueTypes;
using System;
using System.Collections.Generic;

namespace Jambo.Domain.Model.Schools
{
    public class School : AggregateRoot
    {
        private Name name;
        private Teacher manager;
        private List<Parent> parents;
        private List<Teacher> teachers;

        public Name GetName()
        {
            return name;
        }

        public Teacher GetManager()
        {
            return manager;
        }

        private School()
        {
            Register<SchoolCreatedDomainEvent>(When);
        }

        public static School Create()
        {
            School school = new School();
            return school;
        }

        public static School Create(Name name)
        {
            School school = new School();
            school.name = name;

            return school;
        }

        public void CreateWithManager(Teacher teacher)
        {
            Raise(SchoolCreatedDomainEvent.Create(
                this, this.name, teacher.Id, teacher.GetName()));
        }

        private void When(SchoolCreatedDomainEvent domainEvent)
        {
            Id = domainEvent.AggregateRootId;
            name = domainEvent.SchoolName;
            manager = Teacher.Create(domainEvent.ManagerId, domainEvent.ManagerName);
        }

        public void PickChild(Guid childId)
        {

        }

        public void LeaveChild(Guid childId)
        {
            throw new NotImplementedException();
        }

        public void CheckInChild(Guid childId)
        {

        }

        public void CheckOutChild(Guid childId)
        {

        }

        public void CheckOutChild(Guid userId, Guid childId)
        {
            throw new NotImplementedException();
        }

        public void CheckIn(Parent parent, Child child)
        {
            throw new NotImplementedException();
        }

        public void AddTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void AddParent(Parent parent)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void CheckOut(Parent parent, Child child)
        {
            throw new NotImplementedException();
        }

        public void AddChild(Parent parent, Child child)
        {
            throw new NotImplementedException();
        }
    }
}
