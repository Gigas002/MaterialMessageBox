using System;
using System.Windows;
using System.Windows.Media;

// ReSharper disable InheritdocConsiderUsage
// ReSharper disable ClassCanBeSealed.Global
// ReSharper disable MemberCanBeInternal

namespace MaterialMessageBox
{
    /// <summary>
    /// Interaction logic for MaterialMessageBoxWindow.xaml
    /// </summary>
    public partial class MaterialMessageBoxWindow
    {
        #region Non-static members

        /// <summary>
        /// OkButton/CancelButton result.
        /// </summary>
        public MessageBoxResult Result { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MaterialMessageBoxWindow() => InitializeComponent();

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;
            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            Close();
        }

        private void CopyToClipboardButton_OnClick(object sender, RoutedEventArgs e)
        {
            try { Clipboard.SetText(MessageTextBlock.Text); }
            catch (ArgumentNullException)
            {
                // ignored
            }
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Shows usual message box.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="isCancelButtonVisible">(Optional) Is cancel button visible?
        /// <para>By default is <see langword="false"/></para></param>
        /// <param name="isRightToLeft">(Optional) Is <see cref="FlowDirection"/>=<see cref="FlowDirection.RightToLeft"/>?
        /// <para>By default is <see langword="false"/></para></param>
        /// <returns><see cref="MessageBoxResult"/>.</returns>
        public static MessageBoxResult Show(string message, bool isCancelButtonVisible = false,
                                            bool isRightToLeft = false)
        {
            MaterialMessageBoxWindow messageBoxWindow = new MaterialMessageBoxWindow
            {
                MessageTextBlock = { Text = message },
                CancelButton = { Visibility = isCancelButtonVisible ? Visibility.Visible : Visibility.Collapsed },
                FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
            };

            messageBoxWindow.OkButton.Focus();
            messageBoxWindow.ShowDialog();

            return messageBoxWindow.Result;
        }

        /// <summary>
        /// Shows error message box.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        /// <param name="isCancelButtonVisible">(Optional) Is cancel button visible?
        /// <para>By default is <see langword="false"/></para></param>
        /// <param name="isRightToLeft">(Optional) Is <see cref="FlowDirection"/>=<see cref="FlowDirection.RightToLeft"/>?
        /// <para>By default is <see langword="false"/></para></param>
        /// <returns><see cref="MessageBoxResult"/>.</returns>
        public static MessageBoxResult ShowError(string message, bool isCancelButtonVisible = false,
                                                 bool isRightToLeft = false)
        {
            MaterialMessageBoxWindow messageBoxWindow = new MaterialMessageBoxWindow
            {
                BorderBrush = Brushes.Red, BorderThickness = new Thickness(2, 2, 2, 2),
                MessageTextBlock = { Text = message },
                CancelButton = { Visibility = isCancelButtonVisible ? Visibility.Visible : Visibility.Collapsed },
                FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
            };

            messageBoxWindow.OkButton.Focus();
            messageBoxWindow.ShowDialog();

            return messageBoxWindow.Result;
        }

        /// <summary>
        /// Shows warning message box.
        /// </summary>
        /// <param name="message">The warning message to display.</param>
        /// <param name="isCancelButtonVisible">(Optional) Is cancel button visible?
        /// <para>By default is <see langword="false"/></para></param>
        /// <param name="isRightToLeft">(Optional) Is <see cref="FlowDirection"/>=<see cref="FlowDirection.RightToLeft"/>?
        /// <para>By default is <see langword="false"/></para></param>
        /// <returns><see cref="MessageBoxResult"/>.</returns>
        public static MessageBoxResult ShowWarning(string message, bool isCancelButtonVisible = false,
                                                   bool isRightToLeft = false)
        {
            MaterialMessageBoxWindow messageBoxWindow = new MaterialMessageBoxWindow
            {
                BorderBrush = Brushes.Orange, BorderThickness = new Thickness(2, 2, 2, 2),
                MessageTextBlock = { Text = message },
                CancelButton = { Visibility = isCancelButtonVisible ? Visibility.Visible : Visibility.Collapsed },
                FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
            };


            messageBoxWindow.OkButton.Focus();
            messageBoxWindow.ShowDialog();

            return messageBoxWindow.Result;
        }

        #endregion
    }
}
