using System.Linq.Expressions;

namespace Fluently.Framework
{
    public abstract class ConfigureFluently<T>
    {
        private readonly List<IValidationRule> _rules = new();

        protected PropertyRule RuleFor<TProperty>(Expression<Func<T, TProperty>> propertyExpression)
        {
            var propertyName = GetPropertyName(propertyExpression);
            var rule = new PropertyRule(propertyName);
            _rules.Add(rule);
            return rule;
        }

        public List<IValidationRule> GetRules() => _rules;

        protected string GetPropertyName<TProperty>(Expression<Func<T, TProperty>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression member)
            {
                return member.Member.Name;
            }
            throw new ArgumentException("invalid expression.");
        }
    }
}
