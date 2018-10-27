//-----------------------------------------------------------------------
// <copyright file="LinqSort.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.ExtensionMethods
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// IQueryable object sorting Extension Methods.
    /// </summary>
    public static class LinqSort
    {
        #region Private Fields

        /// <summary>
        /// Order By Descending Method Name.
        /// </summary>
        private const string OrderByDescendingMethodName = "OrderByDescending";

        /// <summary>
        /// Order By Method Name.
        /// </summary>
        private const string OrderByMethodName = "OrderBy";

        /// <summary>
        /// Then By Descending Method Name.
        /// </summary>
        private const string ThenByDescendingMethodName = "ThenByDescending";

        /// <summary>
        /// Then By Method Name.
        /// </summary>
        private const string ThenByMethodName = "ThenBy";

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Sorts the elements of a sequence in ascending order by the specified property.
        /// </summary>
        /// <typeparam name="T">The type of elements in the IQueryable object.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="property">Property to sort for.</param>
        /// <returns>IQueryable object of the specified type sorted by the specified column.</returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, OrderByMethodName);
        }

        /// <summary>
        /// Sorts the elements of a sequence in descending order by the specified property.
        /// </summary>
        /// <typeparam name="T">The type of elements in the IQueryable object.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="property">Property to sort for.</param>
        /// <returns>IQueryable object of the specified type sorted by the specified column.</returns>
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, OrderByDescendingMethodName);
        }

        /// <summary>
        /// Performs a subsequent sort of the elements of a sequence in ascending order by the
        /// specified property.
        /// </summary>
        /// <typeparam name="T">The type of elements in the IQueryable object.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="property">Property to sort for.</param>
        /// <returns>IQueryable object of the specified type sorted by the specified column.</returns>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, ThenByMethodName);
        }

        /// <summary>
        /// Performs a subsequent sort of the elements of a sequence in descending order by the
        /// specified property.
        /// </summary>
        /// <typeparam name="T">The type of elements in the IQueryable object.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="property">Property to sort for.</param>
        /// <returns>IQueryable object of the specified type sorted by the specified column.</returns>
        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, ThenByDescendingMethodName);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Applies the specified sort clause.
        /// </summary>
        /// <typeparam name="T">The type of elements in the IQueryable object.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="property">Property to sort for.</param>
        /// <param name="methodName">Sort method to execute.</param>
        /// <returns>IQueryable object of the specified type sorted by the specified parameters.</returns>
        private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                var pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);

            var lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods()
                                             .Single(method => method.Name == methodName
                                                            && method.IsGenericMethodDefinition
                                                            && method.GetGenericArguments().Length == 2
                                                            && method.GetParameters().Length == 2)
                                             .MakeGenericMethod(typeof(T), type)
                                             .Invoke(null, new object[] { source, lambda });

            return (IOrderedQueryable<T>)result;
        }

        #endregion Private Methods
    }
}