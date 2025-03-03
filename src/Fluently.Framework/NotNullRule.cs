namespace Fluently.Framework
{
    public class NotNullRule : IValidationRule
    {
        public string PropertyName { get; }
        public string ErrorMessage { get; private set; }

        public NotNullRule(string propertyName)
        {
            PropertyName = propertyName;
        }

        public void Accept(IValidationVisitor visitor) => visitor.Visit(this);

        public string GetErrorMessage()
        {
            return ErrorMessage ?? $"{PropertyName} is Null";
        }
        public void SetErrorMessage(string message)
        {
            ErrorMessage = message;
        }
    }
}
