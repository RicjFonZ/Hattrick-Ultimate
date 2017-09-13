//-----------------------------------------------------------------------
// <copyright file="ColumnLength.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Constants
{
    /// <summary>
    /// Database table column length constants.
    /// </summary>
    internal class ColumnLength
    {
        #region Fields

        /// <summary>
        /// Long text column length.
        /// </summary>
        internal const int LongText = 512;

        /// <summary>
        /// Medium text column length.
        /// </summary>
        internal const int MediumText = 256;

        /// <summary>
        /// Mini text column length.
        /// </summary>
        internal const int MiniText = 8;

        /// <summary>
        /// Short text column length.
        /// </summary>
        internal const int ShortText = 128;

        /// <summary>
        /// Token column length.
        /// </summary>
        internal const int Token = 16;

        #endregion Fields
    }
}