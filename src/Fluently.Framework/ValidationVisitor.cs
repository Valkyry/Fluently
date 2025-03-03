namespace Fluently.Framework
{
    internal class ValidationVisitor : IValidationVisitor
    {
        private readonly object _targetObject;
        private readonly List<string> _errors = [];

        protected ValidationVisitor(object targetObject)
        {
            _targetObject = targetObject;
        }

        public void Visit(NotNullRule notNullRule)
        {
            var propertyValue = _targetObject.GetType().GetProperty(notNullRule.PropertyName)?.GetValue(_targetObject);
            if (propertyValue == null || string.IsNullOrEmpty(propertyValue.ToString()))
            {
                _errors.Add(notNullRule.GetErrorMessage());
            }
        }

        public void Visit(MaxLength stringLengthRule)
        {
            var propertyType = _targetObject.GetType();
            var propertyName = propertyType.GetProperty(stringLengthRule.PropertyName);

            if (propertyType != typeof(string))
            {
                throw new ArgumentException($"Configuration for {propertyName} is invalid. this method only works with type of string"); 
            }

            var propertyValue = propertyName?.GetValue(_targetObject) as string;
            if (propertyValue != null && propertyValue.Length > stringLengthRule.Length)
            {
                _errors.Add(stringLengthRule.GetErrorMessage());
            }
        }

        public List<string> GetErrors() => _errors;
    }
}
