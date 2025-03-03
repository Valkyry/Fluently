namespace Fluently.Framework
{
    public interface IValidationRule
    {
        void Accept(IValidationVisitor visitor);
        string GetErrorMessage();
    }
}
