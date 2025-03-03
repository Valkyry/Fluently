namespace Fluently.Framework
{
    public class PropertyRule : IValidationRule
    {
        public string PropertyName { get; }
        private readonly List<IValidationRule> _validationRules = [];
        private string _customErrorMessage;

        public PropertyRule(string propertyName)
        {
            PropertyName = propertyName;
        }

        public PropertyRule NotNullOrEmpty()
        {
            var rule = new NotNullRule(PropertyName);
            if (!string.IsNullOrEmpty(_customErrorMessage))
            {
                rule.SetErrorMessage(_customErrorMessage);
            }
            _validationRules.Add(rule);
            return this;
        }

        public PropertyRule MaxLength(int max)
        {
            var rule = new MaxLength(PropertyName, max);
            if (!string.IsNullOrEmpty(_customErrorMessage))
            {
                rule.SetErrorMessage(_customErrorMessage);
            }
            _validationRules.Add(rule);
            return this;
        }
        public PropertyRule WithMessage(string message)
        {
            _customErrorMessage = message;
            return this;
        }

        public string GetErrorMessage()
        {
            return _customErrorMessage;
        }

        public void Accept(IValidationVisitor visitor)
        {
            foreach (var rule in _validationRules)
            {
                rule.Accept(visitor);
            }
        }

    }
}
