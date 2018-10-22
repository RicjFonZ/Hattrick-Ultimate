//-----------------------------------------------------------------------
// <copyright file="LocalizablePropertyAttribute.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Localization
{
    using System;

    /// <summary>
    /// Localizable Property Attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class LocalizablePropertyAttribute : Attribute
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizablePropertyAttribute"/> class.
        /// </summary>
        /// <param name="categoryResourceName">Category Resource Type Name.</param>
        /// <param name="displaynameResourceName">Display Name Resource Type Name.</param>
        /// <param name="descriptionResourceName">Description Resource Type Name.</param>
        /// <param name="resourceType">Resource Type.</param>
        public LocalizablePropertyAttribute(string categoryResourceName, string displaynameResourceName, string descriptionResourceName, Type resourceType)
        {
            this.CategoryResourceName = categoryResourceName;
            this.DisplayNameResourceName = displaynameResourceName;
            this.DescriptionResourceName = descriptionResourceName;
            this.ResourceType = resourceType;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the Category Resource Type Name.
        /// </summary>
        public string CategoryResourceName { get; private set; }

        /// <summary>
        /// Gets the Description Resource Type Name.
        /// </summary>
        public string DescriptionResourceName { get; private set; }

        /// <summary>
        /// Gets the Display Name Resource Type Name.
        /// </summary>
        public string DisplayNameResourceName { get; private set; }

        /// <summary>
        /// Gets the Resource Type Name.
        /// </summary>
        public Type ResourceType { get; private set; }

        #endregion Public Properties
    }
}