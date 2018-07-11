//-----------------------------------------------------------------------
// <copyright file="LocalizedPropertyGridDescriptor.cs" company="Hyperar">
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
    /// TODO: Update summary.
    /// </summary>
    internal class LocalizablePropertyDescriptor : PropertyDescriptor
    {
        #region Private Fields

        private PropertyDescriptor basePropertyDescriptor;

        #endregion Private Fields

        #region Public Constructors

        public LocalizablePropertyDescriptor(PropertyDescriptor basePropertyDescriptor) : base(basePropertyDescriptor)
        {
            this.basePropertyDescriptor = basePropertyDescriptor;
        }

        #endregion Public Constructors

        #region Public Properties

        public override string Category
        {
            get
            {
                Type resourceType = null;
                string category = null;

                var attribute = this.basePropertyDescriptor.Attributes.Cast<Attribute>().SingleOrDefault(a => a.GetType().Equals(typeof(LocalizablePropertyAttribute)));

                if (attribute != null)
                {
                    category = ((LocalizablePropertyAttribute)attribute).CategoryResourceName;
                    resourceType = ((LocalizablePropertyAttribute)attribute).ResourceType;
                }

                if (category.Length == 0)
                {
                    category = this.basePropertyDescriptor.DisplayName + "Category";
                }

                ResourceManager rm = new ResourceManager(resourceType);

                string localizedResourceValue = rm.GetString(category);

                return (localizedResourceValue != null)
                     ? localizedResourceValue
                     : null;
            }
        }

        public override Type ComponentType
        {
            get { return basePropertyDescriptor.ComponentType; }
        }

        /// <summary>
        /// Gets the description of the member, as specified in the System.ComponentModel.DescriptionAttribute.
        /// </summary>
        public override string Description
        {
            get
            {
                Type resourceType = null;
                string description = null;

                var attribute = this.basePropertyDescriptor.Attributes.Cast<Attribute>().SingleOrDefault(a => a.GetType().Equals(typeof(LocalizablePropertyAttribute)));

                if (attribute != null)
                {
                    description = ((LocalizablePropertyAttribute)attribute).DescriptionResourceName;
                    resourceType = ((LocalizablePropertyAttribute)attribute).ResourceType;
                }

                if (description.Length == 0)
                {
                    description = this.basePropertyDescriptor.Description + "Description";
                }

                ResourceManager rm = new ResourceManager(resourceType);

                string localizedResourceValue = rm.GetString(description);

                return (localizedResourceValue != null)
                     ? localizedResourceValue
                     : null;
            }
        }

        public override string DisplayName
        {
            get
            {
                Type resourceType = null;
                string displayName = null;

                var attribute = this.basePropertyDescriptor.Attributes.Cast<Attribute>().SingleOrDefault(a => a.GetType().Equals(typeof(LocalizablePropertyAttribute)));

                if (attribute != null)
                {
                    displayName = ((LocalizablePropertyAttribute)attribute).DisplayNameResourceName;
                    resourceType = ((LocalizablePropertyAttribute)attribute).ResourceType;
                }

                if (displayName.Length == 0)
                {
                    displayName = this.basePropertyDescriptor.DisplayName + "DisplayName";
                }

                ResourceManager rm = new ResourceManager(resourceType);

                string localizedResourceValue = rm.GetString(displayName);

                return (localizedResourceValue != null)
                     ? localizedResourceValue
                     : null;
            }
        }

        public override bool IsReadOnly
        {
            get { return this.basePropertyDescriptor.IsReadOnly; }
        }

        public override string Name
        {
            get { return this.basePropertyDescriptor.Name; }
        }

        public override Type PropertyType
        {
            get { return this.basePropertyDescriptor.PropertyType; }
        }

        #endregion Public Properties

        #region Public Methods

        public override bool CanResetValue(object component)
        {
            return basePropertyDescriptor.CanResetValue(component);
        }

        public override object GetValue(object component)
        {
            return this.basePropertyDescriptor.GetValue(component);
        }

        public override void ResetValue(object component)
        {
            this.basePropertyDescriptor.ResetValue(component);
        }

        public override void SetValue(object component, object value)
        {
            this.basePropertyDescriptor.SetValue(component, value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return this.basePropertyDescriptor.ShouldSerializeValue(component);
        }

        #endregion Public Methods
    }
}