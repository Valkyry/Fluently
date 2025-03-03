namespace Fluently.Framework
{
    public class MaxLength : IValidationRule
    {
        public string PropertyName { get; }
        public int Length { get; }
        public string ErrorMessage { get; private set; }    

        public MaxLength(string propertyName, int length)
        {
            PropertyName = propertyName;
            Length = length;
        }

        public void Accept(IValidationVisitor visitor) => visitor.Visit(this);

        public string GetErrorMessage()
        {
            return ErrorMessage ?? $"{PropertyName} exceed {Length} characters";
        }
        public void SetErrorMessage(string message)
        {
            ErrorMessage = message;
        }
    }
}
