using MFA.Domain.Model.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFA.Domain.Model.Parents
{
    public class Parent : AggregateRoot
    {
        private Name name;

        public static Parent Create()
        {
            return new Parent();
        }

        public void PickChild()
        {

        }

        public void LeaveChild()
        {

        }
    }
}
