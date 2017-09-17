using MFA.Domain.Model.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFA.Domain.Model.Teachers
{
    public class Teacher : AggregateRoot
    {
        private Name name;

        public void CheckInChild()
        {

        }

        public void CheckOutChild()
        {

        }
    }
}
