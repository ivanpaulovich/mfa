using Jambo.Domain.Model.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Model.Schools
{
    public class Parent : Entity
    {
        private Name name;

        private Parent()
        {

        }

        public static Parent Create()
        {
            return new Parent();
        }
    }
}
