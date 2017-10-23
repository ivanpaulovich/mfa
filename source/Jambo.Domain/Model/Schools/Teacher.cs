using System;
using Jambo.Domain.Model.ValueTypes;

namespace Jambo.Domain.Model.Schools
{
    public class Teacher : Entity
    {
        private Name name;

        public Name GetName()
        {
            return name;
        }

        private Teacher()
        {

        }

        public static Teacher Create(Name name)
        {
            Teacher teacher = new Teacher();
            teacher.name = name;

            return teacher;
        }

        public static Teacher Create(Guid teacherId, Name name)
        {
            Teacher teacher = new Teacher();
            teacher.Id = teacherId;
            teacher.name = name;

            return teacher;
        }
    }
}
