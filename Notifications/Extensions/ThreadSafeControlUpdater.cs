// This class taken from somewhere on the internet and changed (improved) little bit

using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace ToastNotifications.Extensions
{
    /// <summary>
    /// Extension class which adds support for windows forms controls to be updated from different threads
    /// </summary>
    public static class ThreadSafeControlUpdater
    {
        delegate void SetPropertyThreadSafeDelegate<TResult>(
    Control @this,
    Expression<Func<TResult>> property,
    TResult value);
        /// <summary>
        /// Extension method which can assign value to System.Windows.Forms.Control property in thread-safe way
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="this">Windows forms control</param>
        /// <param name="property">property locator function. usage: "() => controlVariableName.ControlPropertyName" </param>
        /// <param name="value">Value to be assigned</param>
        public static void SetPropertyThreadSafe<TResult>(
            this Control @this,
            Expression<Func<TResult>> property,
            TResult value)
        {
            var propertyInfo = (property.Body as MemberExpression).Member
                as PropertyInfo;

            if (propertyInfo == null ||
                !(@this.GetType().IsAssignableFrom(propertyInfo.ReflectedType) || @this.GetType().IsSubclassOf(propertyInfo.ReflectedType)) ||
                @this.GetType().GetProperty(
                    propertyInfo.Name,
                    propertyInfo.PropertyType) == null)
            {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }

            if (@this.InvokeRequired)
            {
                @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>
                (SetPropertyThreadSafe), @this, property, value);
            }
            else
            {
                @this.GetType().InvokeMember(
                    propertyInfo.Name,
                    BindingFlags.SetProperty,
                    null,
                    @this,
                    new object[] { value });
            }
        }
    }
}
