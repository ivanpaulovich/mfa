using MFA.Domain.Exceptions;

namespace MFA.Domain.Model.ValueTypes
{
    public class Name
    {
        private string text;

        private Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new DomainException("The content field is required");

            this.text = text;
        }

        public static Name Create(string text)
        {
            return new Name(text);
        }

        public override string ToString()
        {
            return text.ToString();
        }
    }
}