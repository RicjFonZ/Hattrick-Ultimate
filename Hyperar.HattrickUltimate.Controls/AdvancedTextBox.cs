//-----------------------------------------------------------------------
// <copyright file="AdvancedTextBox.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Controls
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// Advanced text box control.
    /// </summary>
    public class AdvancedTextBox : TextBox
    {
        #region Private Fields

        /// <summary>
        /// The text that will be shown when the control is empty.
        /// </summary>
        private string placeholder;

        /// <summary>
        /// A value indicating whether the placeholder will remain when the control gains focus or not.
        /// </summary>
        private bool stickyPlaceholder;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the text that will be shown when the control is empty.
        /// </summary>
        [Category("Appearance"),
         Description("The text that will be shown when the control is empty."),
         DefaultValue(typeof(string), "Placeholder...")]
        public string Placeholder
        {
            get
            {
                return this.placeholder;
            }

            set
            {
                this.placeholder = value;
                this.UpdatePlaceholder();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the placeholder text or not.
        /// </summary>
        [Category("Appearance"),
         Description("Indicates whether the placeholder is enabled or not."),
         DefaultValue(typeof(string), "Placeholder...")]
        public bool ShowPlaceholder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the placeholder will remain when the control
        /// gains focus or not.
        /// </summary>
        [Category("Appearance"),
         Description("Indicates whether the placeholder will be shown when the control gains focus."),
         DefaultValue(typeof(string), "Placeholder...")]
        public bool StickyPlaceholder
        {
            get
            {
                return this.stickyPlaceholder;
            }

            set
            {
                this.stickyPlaceholder = value;
                this.UpdatePlaceholder();
            }
        }

        #endregion Public Properties

        #region Protected Methods

        /// <summary>
        /// Raises the Hyperar.HattrickUltimate.Controls.HandleCreated event.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.UpdatePlaceholder();
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Updates the placeholder.
        /// </summary>
        private void UpdatePlaceholder()
        {
            if (this.ShowPlaceholder && this.IsHandleCreated)
            {
                string message = this.ShowPlaceholder
                               ? this.placeholder
                               : null;

                var result = NativeMethods.SendMessage(this.Handle, 0x1501, (IntPtr)Convert.ToInt32(this.stickyPlaceholder), message);

                if (result.ToInt32() != 1)
                {
                    uint errorCode = NativeMethods.GetLastError();

                    throw new Exception($"Send message was unsuccesful. Error code: {errorCode}.");
                }
            }
        }

        #endregion Private Methods

        #region Private Classes

        /// <summary>
        /// Contains the unmanaged libraries calls.
        /// </summary>
        private class NativeMethods
        {
            #region Private Fields

            /// <summary>
            /// Kernel.dll library name.
            /// </summary>
            private const string KernelLibrary = "kernel.dll";

            /// <summary>
            /// Set control placeholder message pointer.
            /// </summary>
            private const uint PlaceholderMessagePointer = 0x1501;

            /// <summary>
            /// User32.dll library name.
            /// </summary>
            private const string UserLibrary = "user32.dll";

            #endregion Private Fields

            #region Public Methods

            /// <summary>
            /// Retrieves the calling thread's last-error code value.
            /// </summary>
            /// <returns>The calling thread's last-error code.</returns>
            [DllImport(KernelLibrary)]
            public static extern uint GetLastError();

            #endregion Public Methods

            #region Internal Methods

            /// <summary>
            /// Sends a message to a control.
            /// </summary>
            /// <param name="hWnd">
            /// A handle to the window whose window procedure will receive the message.
            /// </param>
            /// <param name="msg">The message to be sent.</param>
            /// <param name="wParam">First additional message-specific information.</param>
            /// <param name="lParam">Second additional message-specific information.</param>
            /// <returns>
            /// The return value specifies the result of the message processing; it depends on the
            /// message sent.
            /// </returns>
            [DllImport(UserLibrary, CharSet = CharSet.Unicode)]
            internal static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

            #endregion Internal Methods
        }

        #endregion Private Classes
    }
}