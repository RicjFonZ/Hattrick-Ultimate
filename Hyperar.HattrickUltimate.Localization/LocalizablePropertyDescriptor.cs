//-----------------------------------------------------------------------
// <copyright file="LocalizablePropertyDescriptor.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Localization
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Resources;

    /// <summary>
    /// Provides functionality to process Localizable Property Grid Properties.
    /// </summary>
    internal class LocalizablePropertyDescriptor : PropertyDescriptor
    {
        #region Private Fields

        /// <summary>
        /// Property descriptor.
        /// </summary>
        private PropertyDescriptor propertyDescriptor;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizablePropertyDescriptor" /> class.
        /// </summary>
        /// <param name="propertyDescriptor">Property descriptor.</param>
        public LocalizablePropertyDescriptor(PropertyDescriptor propertyDescriptor) : base(propertyDescriptor)
        {
            this.propertyDescriptor = propertyDescriptor;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the Category.
        /// </summary>
        public override string Category
        {
            get
            {
                Type resourceType = null;
                string category = null;

                var attribute = this.propertyDescriptor.Attributes.Cast<Attribute>().SingleOrDefault(a => a.GetType().Equals(typeof(LocalizablePropertyAttribute)));

                if (attribute != null)
                {
                    category = ((LocalizablePropertyAttribute)attribute).CategoryResourceName;
                    resourceType = ((LocalizablePropertyAttribute)attribute).ResourceType;
                }

                if (category.Length == 0)
                {
                    category = this.propertyDescriptor.DisplayName + "Category";
                }

                ResourceManager rm = new ResourceManager(resourceType);

                string localizedResourceValue = rm.GetString(category);

                return (localizedResourceValue != null)
                     ? localizedResourceValue
                     : null;
            }
        }

        /// <summary>
        /// Gets the Component Type.
        /// </summary>
        public override Type ComponentType
        {
            get { return this.propertyDescriptor.ComponentType; }
        }

        /// <summary>
        /// Gets the Description.
        /// </summary>
        public override string Description
        {
            get
            {
                Type resourceType = null;
                string description = null;

                var attribute = this.propertyDescriptor.Attributes.Cast<Attribute>().SingleOrDefault(a => a.GetType().Equals(typeof(LocalizablePropertyAttribute)));

                if (attribute != null)
                {
                    description = ((LocalizablePropertyAttribute)attribute).DescriptionResourceName;
                    resourceType = ((LocalizablePropertyAttribute)attribute).ResourceType;
                }

                if (description.Length == 0)
                {
                    description = this.propertyDescriptor.Description + "Description";
                }

                ResourceManager rm = new ResourceManager(resourceType);

                string localizedResourceValue = rm.GetString(description);

                return (localizedResourceValue != null)
                     ? localizedResourceValue
                     : null;
            }
        }

        /// <summary>
        /// Gets the Display Name.
        /// </summary>
        public override string DisplayName
        {
            get
            {
                Type resourceType = null;
                string displayName = null;

                var attribute = this.propertyDescriptor.Attributes.Cast<Attribute>().SingleOrDefault(a => a.GetType().Equals(typeof(LocalizablePropertyAttribute)));

                if (attribute != null)
                {
                    displayName = ((LocalizablePropertyAttribute)attribute).DisplayNameResourceName;
                    resourceType = ((LocalizablePropertyAttribute)attribute).ResourceType;
                }

                if (displayName.Length == 0)
                {
                    displayName = this.propertyDescriptor.DisplayName + "DisplayName";
                }

                ResourceManager rm = new ResourceManager(resourceType);

                string localizedResourceValue = rm.GetString(displayName);

                return (localizedResourceValue != null)
                     ? localizedResourceValue
                     : null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the property is Read Only or not.
        /// </summary>
        public override bool IsReadOnly
        {
            get { return this.propertyDescriptor.IsReadOnly; }
        }

        /// <summary>
        /// Gets the Name.
        /// </summary>
        public override string Name
        {
            get { return this.propertyDescriptor.Name; }
        }

        /// <summary>
        /// Gets the Property Type.
        /// </summary>
        public override Type PropertyType
        {
            get { return this.propertyDescriptor.PropertyType; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns whether resetting an object changes its value.
        /// </summary>
        /// <param name="component">The component to test for reset capability.</param>
        /// <returns>True if resetting the component changes its value; otherwise, false.</returns>
        public override bool CanResetValue(object component)
        {
            return this.propertyDescriptor.CanResetValue(component);
        }

        /// <summary>
        /// Gets the current value of the property on a component.
        /// </summary>
        /// <param name="component">The component with the property for which to retrieve the value.</param>
        /// <returns>The value of a property for a given component.</returns>
        public override object GetValue(object component)
        {
            return this.propertyDescriptor.GetValue(component);
        }

        /// <summary>
        /// Resets the value for this property of the component to the default value.
        /// </summary>
        /// <param name="component">The component with the property value that is to be reset to the default value.</param>
        public override void ResetValue(object component)
        {
            this.propertyDescriptor.ResetValue(component);
        }

        /// <summary>
        /// Sets the value of the component to a different value.
        /// </summary>
        /// <param name="component">The component with the property value that is to be set.</param>
        /// <param name="value">The new value.</param>
        public override void SetValue(object component, object value)
        {
            this.propertyDescriptor.SetValue(component, value);
        }

        /// <summary>
        /// Determines a value indicating whether the value of this property needs to be persisted.
        /// </summary>
        /// <param name="component">The component with the property to be examined for persistence.</param>
        /// <returns>True if the property should be persisted; otherwise, false.</returns>
        public override bool ShouldSerializeValue(object component)
        {
            return this.propertyDescriptor.ShouldSerializeValue(component);
        }

        #endregion Public Methods
    }
}