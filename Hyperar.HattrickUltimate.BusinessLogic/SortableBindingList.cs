//-----------------------------------------------------------------------
// <copyright file="SortableBindingList.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Provides a generic collection that supports data binding and additionally supports sorting. If the elements are IComparable it uses that; otherwise compares the ToString().
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class SortableBindingList<T> : BindingList<T> where T : class
    {
        #region Private Fields

        /// <summary>
        /// A value that indicates whether the list is sorted or not.
        /// </summary>
        private bool isSorted;

        /// <summary>
        /// List Sort Direction.
        /// </summary>
        private ListSortDirection sortDirection = ListSortDirection.Ascending;

        /// <summary>
        /// Sort Property Descriptor.
        /// </summary>
        private PropertyDescriptor sortProperty;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        public SortableBindingList()
        {
            this.sortDirection = ListSortDirection.Ascending;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortableBindingList{T}"/> class.
        /// </summary>
        /// <param name="list">An <see cref="T:System.Collections.Generic.IList`1" /> of items to be contained in the <see cref="T:System.ComponentModel.BindingList`1" />.</param>
        public SortableBindingList(IList<T> list)
            : base(list)
        {
        }

        #endregion Public Constructors

        #region Protected Properties

        /// <summary>
        /// Gets a value indicating whether the list is sorted or not.
        /// </summary>
        protected override bool IsSortedCore
        {
            get
            {
                return this.isSorted;
            }
        }

        /// <summary>
        /// Gets the direction the list is sorted.
        /// </summary>
        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return this.sortDirection;
            }
        }

        /// <summary>
        /// Gets the property descriptor that is used for sorting the list if sorting is implemented in a derived class; otherwise, returns null.
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return this.sortProperty;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the list supports sorting.
        /// </summary>
        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        #endregion Protected Properties

        #region Protected Methods

        /// <summary>
        /// Sorts the items if overridden in a derived class.
        /// </summary>
        /// <param name="prop">Property Descriptor.</param>
        /// <param name="direction">Sort Direction.</param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            this.sortProperty = prop;
            this.sortDirection = direction;

            List<T> list = Items as List<T>;

            if (list == null)
            {
                return;
            }

            list.Sort(this.Compare);

            this.isSorted = true;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        /// <summary>
        /// Removes any sort applied with ApplySortCore if sorting is implemented.
        /// </summary>
        protected override void RemoveSortCore()
        {
            this.sortDirection = ListSortDirection.Ascending;
            this.sortProperty = null;
            this.isSorted = false;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Compares two items.
        /// </summary>
        /// <param name="leftHandSide">Left Hand Side Item.</param>
        /// <param name="rightHandSide">Right Hand Side Item.</param>
        /// <returns>Returns an integer value indicating the sorting result.</returns>
        private int Compare(T leftHandSide, T rightHandSide)
        {
            var result = this.OnComparison(leftHandSide, rightHandSide);

            if (this.sortDirection == ListSortDirection.Descending)
            {
                result = -result;
            }

            return result;
        }

        /// <summary>
        /// Compares the items and returns an integer value indicating the sorting result.
        /// </summary>
        /// <param name="leftHandSide">Left Hand Side Item.</param>
        /// <param name="rightHandSide">Right Hand Side Item.</param>
        /// <returns>Returns an integer value indicating the sorting result.</returns>
        private int OnComparison(T leftHandSide, T rightHandSide)
        {
            object leftHandSideValue = leftHandSide == null
                                     ? null
                                     : this.sortProperty.GetValue(leftHandSide);

            object rightHandSideValue = rightHandSide == null
                                      ? null
                                      : this.sortProperty.GetValue(rightHandSide);

            if (leftHandSideValue == null)
            {
                return (rightHandSideValue == null) ? 0 : -1;
            }

            if (rightHandSideValue == null)
            {
                return 1;
            }

            if (leftHandSideValue is IComparable)
            {
                return ((IComparable)leftHandSideValue).CompareTo(rightHandSideValue);
            }

            if (leftHandSideValue.Equals(rightHandSideValue))
            {
                return 0;
            }

            return leftHandSideValue.ToString()
                                    .CompareTo(rightHandSideValue.ToString());
        }

        #endregion Private Methods
    }
}