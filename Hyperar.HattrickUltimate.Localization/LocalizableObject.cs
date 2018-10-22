//-----------------------------------------------------------------------
// <copyright file="LocalizableObject.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Localization
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// LocalizableObject implements ICustomTypeDescriptor to enable required functionality to
    /// describe a type (class).
    /// </summary>
    public class LocalizableObject : ICustomTypeDescriptor
    {
        #region Private Fields

        /// <summary>
        /// Localized Property Collection.
        /// </summary>
        private PropertyDescriptorCollection localizedPropertyCollection;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Returns a collection of attributes for the specified component and a Boolean indicating
        /// that a custom type descriptor has been created.
        /// </summary>
        /// <returns>
        /// An System.ComponentModel.AttributeCollection with the attributes for the component. If
        /// the component is null, this method returns an empty collection.
        /// </returns>
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        /// <summary>
        /// Returns the name of the class for the specified component using a custom type descriptor.
        /// </summary>
        /// <returns>A System.String containing the name of the class for the specified component.</returns>
        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        /// <summary>
        /// Returns the name of the specified component using a custom type descriptor.
        /// </summary>
        /// <returns>
        /// The name of the class for the specified component, or null if there is no component name.
        /// </returns>
        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        /// <summary>
        /// Returns a type converter for the type of the specified component with a custom type descriptor.
        /// </summary>
        /// <returns>A System.ComponentModel.TypeConverter for the specified component.</returns>
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        /// <summary>
        /// Returns the default event for a component with a custom type descriptor.
        /// </summary>
        /// <returns>
        /// An System.ComponentModel.EventDescriptor with the default event, or null if there are no events.
        /// </returns>
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        /// <summary>
        /// Returns the default property for the specified component with a custom type descriptor.
        /// </summary>
        /// <returns>
        /// A System.ComponentModel.PropertyDescriptor with the default property, or null if there
        /// are no properties.
        /// </returns>
        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        /// <summary>
        /// Returns an editor with the specified base type and with a custom type descriptor for the
        /// specified component.
        /// </summary>
        /// <param name="editorBaseType">
        /// A System.Type that represents the base type of the editor you want to find.
        /// </param>
        /// <returns>
        /// An instance of the editor that can be cast to the specified editor type, or null if no
        /// editor of the requested type can be found.
        /// </returns>
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        /// <summary>
        /// Returns the collection of events for a specified component using a specified array of
        /// attributes as a filter and using a custom type descriptor.
        /// </summary>
        /// <param name="attributes">An array of type System.Attribute to use as a filter.</param>
        /// <returns>
        /// An System.ComponentModel.EventDescriptorCollection with the events that match the
        /// specified attributes for this component.
        /// </returns>
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        /// <summary>
        /// Returns the collection of events for a specified component with a custom type descriptor.
        /// </summary>
        /// <returns>
        /// An System.ComponentModel.EventDescriptorCollection with the events for this component.
        /// </returns>
        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        /// <summary>
        /// Returns the collection of properties for a specified component using a specified array of
        /// attributes as a filter and using a custom type descriptor.
        /// </summary>
        /// <param name="attributes">An array of type System.Attribute to use as a filter.</param>
        /// <returns>
        /// A System.ComponentModel.PropertyDescriptorCollection with the events that match the
        /// specified attributes for the specified component.
        /// </returns>
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            if (this.localizedPropertyCollection == null)
            {
                // Get the collection of properties
                var baseProps = TypeDescriptor.GetProperties(this, attributes, true);

                this.localizedPropertyCollection = new PropertyDescriptorCollection(null);

                // For each property use a property descriptor of our own that is able to be localized.
                foreach (PropertyDescriptor curProp in baseProps)
                {
                    this.localizedPropertyCollection.Add(new LocalizablePropertyDescriptor(curProp));
                }
            }

            return this.localizedPropertyCollection;
        }

        /// <summary>
        /// Returns the collection of properties for a specified component using the default type descriptor.
        /// </summary>
        /// <returns>
        /// A System.ComponentModel.PropertyDescriptorCollection with the properties for a specified component.
        /// </returns>
        public PropertyDescriptorCollection GetProperties()
        {
            // Only do once
            if (this.localizedPropertyCollection == null)
            {
                // Get the collection of properties
                var baseProps = TypeDescriptor.GetProperties(this, true);
                this.localizedPropertyCollection = new PropertyDescriptorCollection(null);

                // For each property use a property descriptor of our own that is able to be localized.
                foreach (PropertyDescriptor curProp in baseProps)
                {
                    this.localizedPropertyCollection.Add(new LocalizablePropertyDescriptor(curProp));
                }
            }

            return this.localizedPropertyCollection;
        }

        /// <summary>
        /// Returns an object that contains the property described by the specified property descriptor.
        /// </summary>
        /// <param name="pd">
        /// A System.ComponentModel.PropertyDescriptor that represents the property whose owner is to
        /// be found.
        /// </param>
        /// <returns>An System.Object that represents the owner of the specified property.</returns>
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion Public Methods
    }
}