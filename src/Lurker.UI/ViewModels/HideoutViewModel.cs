﻿//-----------------------------------------------------------------------
// <copyright file="HideoutViewModel.cs" company="Wohs Inc.">
//     Copyright © Wohs Inc.
// </copyright>
//-----------------------------------------------------------------------

namespace Lurker.UI.ViewModels
{
    using Caliburn.Micro;
    using Lurker;
    using Lurker.Helpers;
    using Lurker.Models;
    using Lurker.Services;

    /// <summary>
    /// Represents the Hideout overlay.
    /// </summary>
    /// <seealso cref="Lurker.UI.ViewModels.PoeOverlayBase" />
    public class HideoutViewModel : PoeOverlayBase
    {
        #region Fields

        private static readonly int DefaultSize = 60;
        private PoeKeyboardHelper _keyboardHelper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HideoutViewModel" /> class.
        /// </summary>
        /// <param name="windowManager">The window manager.</param>
        /// <param name="dockingHelper">The docking helper.</param>
        /// <param name="processLurker">The process lurker.</param>
        /// <param name="settingsService">The settings service.</param>
        /// <param name="keyboardHelper">The keyboard helper.</param>
        public HideoutViewModel(IWindowManager windowManager, DockingHelper dockingHelper, ProcessLurker processLurker, SettingsService settingsService, PoeKeyboardHelper keyboardHelper)
            : base(windowManager, dockingHelper, processLurker, settingsService)
        {
            this._keyboardHelper = keyboardHelper;
        }

        #endregion

        /// <summary>
        /// Joins the hideout.
        /// </summary>
        public void JoinHideout()
        {
            this._keyboardHelper.JoinHideout();
        }

        /// <summary>
        /// Sets the window position.
        /// </summary>
        /// <param name="windowInformation">The window information.</param>
        protected override void SetWindowPosition(PoeWindowInformation windowInformation)
        {
            var value = DefaultSize * windowInformation.Height / 1080;
            var margin = PoeApplicationContext.WindowStyle == WindowStyle.Windowed ? 10 : 0;

            Execute.OnUIThread(() =>
            {
                this.View.Height = value;
                this.View.Width = value;
                this.View.Left = windowInformation.Position.Left + margin;
                this.View.Top = windowInformation.Position.Bottom - value - margin;
            });
        }
    }
}