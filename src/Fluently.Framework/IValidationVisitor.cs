namespace Fluently.Framework
{
    public interface IValidationVisitor
    {
        void Visit(NotNullRule notNullRule);
        void Visit(MaxLength maxLengthRule);
        List<string> GetErrors();
    }
}
