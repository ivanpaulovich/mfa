using Jambo.Domain.Exceptions;

namespace Jambo.Domain.Model.ValueTypes
{
    public class Name
    {
        private string text;

        public string Text
        {
            get
            {
                return text;
            }
        }

        public Name(string text)
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