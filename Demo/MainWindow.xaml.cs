using System;
using System.Windows;
using System.Windows.Media;
using MaterialMessageBox;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private async void ShowSimpleMessageBox_OnClick(object sender, RoutedEventArgs e)
        {
            await
                MaterialMessageBoxUserControl
                    .Show("This is a simple message\n\nIs\'nt it cool\n.\n.\n" + "You could even scroll!!!\nd\no\no\no\no\no\nw\nn",
                          false);
        }

        private void ShowErrorMessageBox_OnClick(object sender, RoutedEventArgs e)
        {
            MaterialMessageBoxWindow.ShowError("This is an error message", false);
        }

        private void ShowMessageBoxWithCancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MaterialMessageBoxWindow.Show("This is a simple message with a cancel button."
                                                                      + " You can listen to the return value", true);
            TxtResult.Text = $"Message Box Result is: {result}";
        }

        private void ShowCustomMessageBox_OnClick(object sender, RoutedEventArgs e)
        {
            //You can create this as a static class and reuse it all over your app

            MaterialMessageBoxWindow materialMessageBoxWindow = new MaterialMessageBoxWindow
            {
                MessageTextBlock = { Text = "Do you like white wine?", Foreground = Brushes.White },
                OkButton = { Content = "Yes" }, CancelButton = { Content = "Noooo" },
                MainGrid = { Background = Brushes.Red }, BorderBrush = Brushes.BlueViolet,
                BorderThickness = new Thickness(4, 4, 4, 4)
            };
            materialMessageBoxWindow.ShowDialog();
            TxtResult.Text = $"Message Box Result is: {materialMessageBoxWindow.Result}";
        }

        private async void ShowSimpleRTLMessageBox_OnClick(object sender, RoutedEventArgs e) =>
            await MaterialMessageBoxUserControl.Show(
                $"This is a simple message{Environment.NewLine}هذه رسالة بسيطة{Environment.NewLine}{Environment.NewLine}"
              + "Is'nt it cool\n.\n.\nYou could even scroll!!!\nd\no\no\no\no\no\nw\nn", false, true);
    }
}
