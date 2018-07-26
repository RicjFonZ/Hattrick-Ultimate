//-----------------------------------------------------------------------
// <copyright file="ColumnType.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Constants
{
    /// <summary>
    /// Database table column data type constants.
    /// </summary>
    internal class ColumnType
    {
        #region Internal Fields

        /// <summary>
        /// Big integer column data type.
        /// </summary>
        internal const string BigInt = "bigint";

        /// <summary>
        /// Boolean column data type.
        /// </summary>
        internal const string Boolean = "bit";

        /// <summary>
        /// DateTime column data type.
        /// </summary>
        internal const string DateTime = "datetime";

        /// <summary>
        /// Integer column data type.
        /// </summary>
        internal const string Integer = "int";

        /// <summary>
        /// Numeric column data type.
        /// </summary>
        internal const string Numeric = "numeric";

        /// <summary>
        /// Small Integer column data type.
        /// </summary>
        internal const string SmallInt = "smallint";

        /// <summary>
        /// Time column data type.
        /// </summary>
        internal const string Time = "time";

        /// <summary>
        /// Tiny integer column data type.
        /// </summary>
        internal const string TinyInt = "tinyint";

        /// <summary>
        /// Unicode char column data type.
        /// </summary>
        internal const string UnicodeChar = "nchar";

        /// <summary>
        /// Unicode variable char column data type.
        /// </summary>
        internal const string UnicodeVarChar = "nvarchar";

        /// <summary>
        /// Variable Binary MAX column data type.
        /// </summary>
        internal const string VarBinaryMax = "varbinary(max)";

        #endregion Internal Fields
    }
}