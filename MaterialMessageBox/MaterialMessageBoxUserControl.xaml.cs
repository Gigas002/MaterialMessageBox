using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
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
            if (string.IsNullOrWhiteSpace(MessageTextBlock.Text)) return;

            Clipboard.SetText(MessageTextBlock.Text);
        }

        #endregion

        #region Static methods

        #region Async

        /// <summary>
        /// Shows usual message box.
        /// </summary>
        /// <param name="message">The message to display.</param>
        /// <param name="isCancelButtonVisible">(Optional) Is cancel button visible?
        /// <para>By default is <see langword="false"/></para></param>
        /// <param name="isRightToLeft">(Optional) Is <see cref="FlowDirection"/>=<see cref="FlowDirection.RightToLeft"/>?
        /// <para>By default is <see langword="false"/></para></param>
        /// <returns><see cref="MessageBoxResult"/>.</returns>
        public static async ValueTask<MessageBoxResult> ShowAsync(string message,
                                                                  bool isCancelButtonVisible = false,
                                                                  bool isRightToLeft = false)
        {
            MaterialMessageBoxUserControl materialMessageBoxUserControl = new MaterialMessageBoxUserControl
            {
                MessageTextBlock = { Text = message },
                CancelButton = { Visibility = isCancelButtonVisible ? Visibility.Visible : Visibility.Collapsed },
                FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
            };
            materialMessageBoxUserControl.OkButton.Focus();
            await DialogHost.Show(materialMessageBoxUserControl).ConfigureAwait(false);

            return materialMessageBoxUserControl.Result;
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
        public static async ValueTask<MessageBoxResult> ShowErrorAsync(string message,
                                                                       bool isCancelButtonVisible = false,
                                                                       bool isRightToLeft = false)
        {
            MaterialMessageBoxUserControl materialMessageBoxUserControl = new MaterialMessageBoxUserControl
            {
                BorderBrush = Brushes.Red, BorderThickness = new Thickness(2, 2, 2, 2),
                MessageTextBlock = { Text = message },
                CancelButton = { Visibility = isCancelButtonVisible ? Visibility.Visible : Visibility.Collapsed },
                FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
            };

            materialMessageBoxUserControl.OkButton.Focus();
            await DialogHost.Show(materialMessageBoxUserControl).ConfigureAwait(false);

            return materialMessageBoxUserControl.Result;
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
        public static async ValueTask<MessageBoxResult> ShowWarningAsync(string message,
                                                                         bool isCancelButtonVisible = false,
                                                                         bool isRightToLeft = false)
        {
            MaterialMessageBoxUserControl materialMessageBoxUserControl = new MaterialMessageBoxUserControl
            {
                BorderBrush = Brushes.Orange, BorderThickness = new Thickness(2, 2, 2, 2),
                MessageTextBlock = { Text = message },
                CancelButton = { Visibility = isCancelButtonVisible ? Visibility.Visible : Visibility.Collapsed },
                FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
            };

            materialMessageBoxUserControl.OkButton.Focus();
            await DialogHost.Show(materialMessageBoxUserControl).ConfigureAwait(false);

            return materialMessageBoxUserControl.Result;
        }

        #endregion

        #region Sync

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
            MaterialMessageBoxUserControl materialMessageBoxUserControl = new MaterialMessageBoxUserControl
            {
                MessageTextBlock = { Text = message },
                CancelButton = { Visibility = isCancelButtonVisible ? Visibility.Visible : Visibility.Collapsed },
                FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
            };
            materialMessageBoxUserControl.OkButton.Focus();
            DialogHost.Show(materialMessageBoxUserControl);

            return materialMessageBoxUserControl.Result;
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
            MaterialMessageBoxUserControl materialMessageBoxUserControl = new MaterialMessageBoxUserControl
            {
                BorderBrush = Brushes.Red, BorderThickness = new Thickness(2, 2, 2, 2),
                MessageTextBlock = { Text = message },
                CancelButton = { Visibility = isCancelButtonVisible ? Visibility.Visible : Visibility.Collapsed },
                FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
            };

            materialMessageBoxUserControl.OkButton.Focus();
            DialogHost.Show(materialMessageBoxUserControl);

            return materialMessageBoxUserControl.Result;
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
            MaterialMessageBoxUserControl materialMessageBoxUserControl = new MaterialMessageBoxUserControl
            {
                BorderBrush = Brushes.Orange, BorderThickness = new Thickness(2, 2, 2, 2),
                MessageTextBlock = { Text = message },
                CancelButton = { Visibility = isCancelButtonVisible ? Visibility.Visible : Visibility.Collapsed },
                FlowDirection = isRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight
            };

            materialMessageBoxUserControl.OkButton.Focus();
            DialogHost.Show(materialMessageBoxUserControl);

            return materialMessageBoxUserControl.Result;
        }

        #endregion

        #endregion
    }
}
