using System;
using System.Threading.Tasks;
using System.Windows;
using MaterialDesignThemes.Wpf;

// ReSharper disable InheritdocConsiderUsage
// ReSharper disable ClassCanBeSealed.Global
// ReSharper disable MemberCanBeInternal

namespace MaterialMessageBox
{
    /// <summary>
    /// Interaction logic for MaterialMessageBoxUserControl.xaml
    /// </summary>
    public partial class MaterialMessageBoxUserControl
    {
        #region Non-static members

        /// <summary>
        /// OkButton/CancelButton result.
        /// </summary>
        public MessageBoxResult Result { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MaterialMessageBoxUserControl() => InitializeComponent();

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;
            DialogHost.CloseDialogCommand.Execute(true, null);
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            DialogHost.CloseDialogCommand.Execute(false, null);
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
        /// <param name="isCancel">Is cancel button visible?</param>
        /// <param name="isRightToLeft">(Optional) Is <see cref="FlowDirection"/>=<see cref="FlowDirection.RightToLeft"/>?</param>
        /// <returns><see cref="MessageBoxResult"/>.
        /// <para>Also returns <see cref="MessageBoxResult.Cancel"/> if <see cref="Exception"/> is thrown.</para></returns>
        public static async ValueTask<MessageBoxResult> Show(string message, bool isCancel, bool isRightToLeft = false)
        {
            try
            {
                MaterialMessageBoxUserControl mbc = new MaterialMessageBoxUserControl();
                mbc.MessageTextBlock.Text = message;
                mbc.CancelButton.Visibility = isCancel ? Visibility.Visible : Visibility.Collapsed;
                mbc.FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
                mbc.OkButton.Focus();
                //mbc.ShowDialog();
                await DialogHost.Show(mbc);
                return mbc.Result == MessageBoxResult.OK ? MessageBoxResult.OK : MessageBoxResult.Cancel;
            }
            catch (Exception)
            {
                return MessageBoxResult.Cancel;
            }
        }

        /// <summary>
        /// Shows an error message box.
        /// </summary>
        /// <param name="errorMessage">The error error message to display.</param>
        /// <param name="isCancel">Is cancel button visible?</param>
        /// <param name="isRightToLeft">(Optional) Is <see cref="FlowDirection"/>=<see cref="FlowDirection.RightToLeft"/>?</param>
        /// <returns>Message box result. <see cref="MessageBoxResult.Cancel"/> if <see cref="Exception"/> is thrown.</returns>
        public static MessageBoxResult ShowError(string errorMessage, bool isCancel, bool isRightToLeft = false)
        {
            //try
            //{
            //    using (MessageBoxWindow messageBoxWindow = new MessageBoxWindow())
            //    {
            //        messageBoxWindow.BorderBrush = Brushes.Red;
            //        messageBoxWindow.BorderThickness = new Thickness(2, 2, 2, 2);

            //        messageBoxWindow.MessageTextBlock.Text = errorMessage;
            //        messageBoxWindow.CancelButton.Visibility = isCancel ? Visibility.Visible : Visibility.Collapsed;
            //        messageBoxWindow.FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            //        messageBoxWindow.OkButton.Focus();
            //        messageBoxWindow.ShowDialog();
            //        return messageBoxWindow.Result == MessageBoxResult.OK ? MessageBoxResult.OK : MessageBoxResult.Cancel;
            //    }
            //}
            //catch (Exception)
            //{
            return MessageBoxResult.Cancel;
            //}
        }

        /// <summary>
        /// Shows a warning message box.
        /// </summary>
        /// <param name="warningMessage">The warning message to display.</param>
        /// <param name="isCancel">Is cancel button visible?</param>
        /// <param name="isRightToLeft">(Optional) Is <see cref="FlowDirection"/>=<see cref="FlowDirection.RightToLeft"/>?</param>
        /// <returns>Message box result. <see cref="MessageBoxResult.Cancel"/> if <see cref="Exception"/> is thrown.</returns>
        public static MessageBoxResult ShowWarning(string warningMessage, bool isCancel, bool isRightToLeft = false)
        {
            //try
            //{
            //    using (MessageBoxWindow messageBoxWindow = new MessageBoxWindow())
            //    {
            //        messageBoxWindow.BorderBrush = Brushes.Orange;
            //        messageBoxWindow.BorderThickness = new Thickness(2, 2, 2, 2);

            //        messageBoxWindow.MessageTextBlock.Text = warningMessage;
            //        messageBoxWindow.CancelButton.Visibility = isCancel ? Visibility.Visible : Visibility.Collapsed;
            //        messageBoxWindow.FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            //        messageBoxWindow.OkButton.Focus();
            //        messageBoxWindow.ShowDialog();
            //        return messageBoxWindow.Result == MessageBoxResult.OK ? MessageBoxResult.OK : MessageBoxResult.Cancel;
            //    }
            //}
            //catch (Exception)
            //{
            return MessageBoxResult.Cancel;
            //}
        }

        #endregion
    }
}
