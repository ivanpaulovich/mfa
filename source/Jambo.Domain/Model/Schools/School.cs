using Jambo.Domain.Model.Schools.Events;
using Jambo.Domain.Model.ValueTypes;
using System.Collections.Generic;

namespace Jambo.Domain.Model.Schools
{
    public class School : AggregateRoot
    {
        private Name name;
        private Teacher manager;
        private List<Parent> parents;
        private List<Teacher> teachers;
        private List<Child> children;

        public Name GetName()
        {
            return name;
        }

        public Teacher GetManager()
        {
            return manager;
        }

        public IReadOnlyCollection<Parent> GetParents()
        {
            return parents;
        }

        public IReadOnlyCollection<Teacher> GetTeachers()
        {
            return teachers;
        }

        public IReadOnlyCollection<Child> GetChildren()
        {
            return children;
        }

        private School()
        {
            Register<SchoolCreatedDomainEvent>(When);
            Register<TeacherAddedDomainEvent>(When);
            Register<ParentAddedDomainEvent>(When);
            Register<ChildAddedDomainEvent>(When);
            Register<ChildCheckedInDomainEvent>(When);
            Register<ChildCheckedOutDomainEvent>(When);
            Register<ChildLeftDomainEvent>(When);
            Register<ChildPickedUpDomainEvent>(When);
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

        public void Pick(Parent parent, Child child)
        {
            Raise(ChildPickedUpDomainEvent.Create(
                this, child.Id));
        }

        private void When(ChildPickedUpDomainEvent domainEvent)
        {
            foreach (Child child in children)
            {
                if (child.Id == domainEvent.ChildId)
                    child.Pickup();
            }
        }

        public void Leave(Parent parent, Child child)
        {
            Raise(ChildLeftDomainEvent.Create(this, child.Id));
        }

        private void When(ChildLeftDomainEvent domainEvent)
        {
            foreach (Child child in children)
            {
                if (child.Id == domainEvent.ChildId)
                    child.Left();
            }
        }

        public void CheckIn(Teacher teacher, Child child)
        {
            Raise(ChildCheckedInDomainEvent.Create(
                this, child.Id));
        }

        private void When(ChildCheckedInDomainEvent domainEvent)
        {
            foreach (Child child in children)
            {
                if (child.Id == domainEvent.ChildId)
                    child.CheckIn();
            }
        }

        public void CheckOut(Teacher teacher, Child child)
        {
            Raise(ChildCheckedOutDomainEvent.Create(
                this, child.Id));
        }

        private void When(ChildCheckedOutDomainEvent domainEvent)
        {
            foreach (Child child in children)
            {
                if (child.Id == domainEvent.ChildId)
                    child.CheckOut();
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            Raise(TeacherAddedDomainEvent.Create(this, teacher.Id, teacher.GetName()));
        }

        private void When(TeacherAddedDomainEvent domainEvent)
        {
            teachers = teachers ?? new List<Teacher>();
            Teacher teacher = Teacher.Create(domainEvent.TeacherId, domainEvent.TeacherName);

            teachers.Add(teacher);
        }

        public void AddParent(Parent parent)
        {
            Raise(ParentAddedDomainEvent.Create(this, parent.Id, 
                parent.GetName(), 
                parent.GetIdentification(), 
                parent.GetBirthDate()));
        }

        private void When(ParentAddedDomainEvent domainEvent)
        {
            parents = parents ?? new List<Parent>();
            Parent parent = Parent.Create(
                domainEvent.ParentId, 
                domainEvent.Name,
                domainEvent.Identification,
                domainEvent.BirthDate);

            parents.Add(parent);
        }

        public void AddChild(Parent parent, Child child)
        {
            Raise(ChildAddedDomainEvent.Create(this,  
                parent.Id,
                child.Id,
                child.GetName(),
                child.GetBirthDate()));
        }

        private void When(ChildAddedDomainEvent domainEvent)
        {
            children = children ?? new List<Child>();

            Child child = Child.Create(
                domainEvent.ChildId,
                domainEvent.Name,
                domainEvent.BirthDate,
                Custody.Create(CustodyEnum.ChildConfirmedWithFamily));

            children.Add(child);

            foreach (Parent parent in parents)
            {
                if (parent.Id == domainEvent.ParentId)
                    parent.AddChild(child);
            }
        }
    }
}
