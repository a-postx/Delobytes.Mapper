using System;
using System.Linq.Expressions;

namespace Delobytes.Mapper
{
    /// <summary>
    /// Create instances of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type with a parameterless constructor.</typeparam>
    public static class Factory<T> where T : new()
    {
        private static readonly Func<T> CreateInstanceFunc =
            Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();

        /// <summary>
        /// Create instance of type <typeparamref name="T"/> by calling it's parameterless constructor.
        /// </summary>
        /// <returns>Instance of type <typeparamref name="T"/>.</returns>
        public static T CreateInstance() => CreateInstanceFunc();
    }
}
