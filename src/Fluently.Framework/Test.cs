namespace Fluently.Framework
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Postcode { get; set; }
    }

    public class CustomerValidator : ConfigureFluently<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotNullOrEmpty().WithMessage("It is empty").MaxLength(9).WithMessage("its ex");
        }
    }
}
