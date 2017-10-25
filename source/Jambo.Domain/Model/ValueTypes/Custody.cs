namespace Jambo.Domain.Model.ValueTypes
{
    public class Custody
    {
        private CustodyEnum value;

        public CustodyEnum Value
        {
            get
            {
                return value;
            }
        }

        public Custody(CustodyEnum value)
        {
            this.value = value;
        }

        public static Custody Create(CustodyEnum value)
        {
            return new Custody(value);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
