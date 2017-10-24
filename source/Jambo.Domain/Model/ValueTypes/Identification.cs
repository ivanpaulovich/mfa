using Jambo.Domain.Exceptions;

namespace Jambo.Domain.Model.ValueTypes
{
    public class Identification
    {
        private string text;

        public Identification(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new DomainException("The text field is required");

            this.text = text;
        }

        public static Identification Create(string text)
        {
            return new Identification(text);
        }

        public override string ToString()
        {
            return text.ToString();
        }
    }
}