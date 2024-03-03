using System.Linq.Expressions;

namespace HumanCapitalManagement.Data.Common.Utils;

public static class ExpressionBuilder
{
    public static Expression<Func<TElement, bool>> BuildEqualsFilter<TElement>(object value, string propertyName)
    {
        var parameterExpression = Expression.Parameter(typeof(TElement));

        var leftArgument = Expression.PropertyOrField(parameterExpression, propertyName);
        var rightArgument = Expression.Constant(value);
        var equalsExpression = Expression.Equal(leftArgument, rightArgument);

        return Expression.Lambda<Func<TElement, bool>>(equalsExpression, parameterExpression);
    }
}