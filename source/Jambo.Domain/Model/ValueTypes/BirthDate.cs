using Jambo.Domain.Exceptions;
using System;

namespace Jambo.Domain.Model.ValueTypes
{
    public class BirthDate
    {
        private DateTime value;

        public DateTime Value
        {
            get
            {
                return value;
            }
        }

        public BirthDate(DateTime value)
        {
            DateTime now = DateTime.Today;
            double years = (now - value).Days / 365.25;

            if (years < 0)
                throw new DomainException("The BirthDate should be greater than zero.");

            if (years > 70)
                throw new DomainException("The BirthDate should be less than 70 years.");

            this.value = value;
        }

        public static BirthDate Create(DateTime birthDate)
        {
            return new BirthDate(birthDate);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
