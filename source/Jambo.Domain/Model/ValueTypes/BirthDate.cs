using Jambo.Domain.Exceptions;
using System;

namespace Jambo.Domain.Model.ValueTypes
{
    public class BirthDate
    {
        private DateTime birthDate;

        public BirthDate(DateTime birthDate)
        {
            DateTime now = DateTime.Today;
            double years = (now - birthDate).Days / 365.25;

            if (years < 0)
                throw new DomainException("The BirthDate should be greater than zero.");

            if (years > 70)
                throw new DomainException("The BirthDate should be less than 70 years.");

            this.birthDate = birthDate;
        }

        public static BirthDate Create(DateTime birthDate)
        {
            return new BirthDate(birthDate);
        }

        public override string ToString()
        {
            return birthDate.ToString();
        }
    }
}
