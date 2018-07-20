//-----------------------------------------------------------------------
// <copyright file="GridColumnType.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App.Enums
{
    /// <summary>
    /// Application Data Grid Column Types.
    /// </summary>
    public enum GridColumnType : byte
    {
        /// <summary>
        /// Text Grid Column Type.
        /// </summary>
        Text = 0,

        /// <summary>
        /// Image Grid Column Type.
        /// </summary>
        Image = 1,

        /// <summary>
        /// Image and Text Grid Column Type.
        /// </summary>
        ImageAndText = 2,

        /// <summary>
        /// Denominated Value Grid Column Type.
        /// </summary>
        DenominatedValue = 3,

        /// <summary>
        /// Denominated Value With Change Tracking Grid Column Type.
        /// </summary>
        DenominatedValueWithChangeTracking = 4,

        /// <summary>
        /// Value With Change Tracking Grid Column Type.
        /// </summary>
        ValueWithChangeTracking = 5
    }
}