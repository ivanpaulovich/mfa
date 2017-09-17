using MFA.Domain.Model.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFA.Domain.Model.Schools
{
    public class School : AggregateRoot
    {
        private Name name;

        private School()
        {

        }

        public static School Create()
        {
            return new School();
        }

        public void PickChild(Guid childId)
        {

        }

        public void CheckInChild(Guid childId)
        {

        }

        public void CheckOutChild(Guid childId)
        {

        }

        public void LeaveChild(Guid childId)
        {
            throw new NotImplementedException();
        }
    }
}
