using System;
using System.Windows;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using MaterialMessageBox;

// ReSharper disable InheritdocConsiderUsage

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal sealed partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private string MessageBoxMessage { get; } =
            "The Soviet Union, officially the Union of Soviet Socialist Republics (USSR), was a Marxist-Leninist sovereign state in Eurasia that existed from 1922 to 1991. Nominally a union of multiple national Soviet republics, its government and economy were highly centralized. The country was a one-party state, governed by the Communist Party with Moscow as its capital in its largest republic, the Russian Soviet Federative Socialist Republic (Russian SFSR). Other major urban centers were Leningrad, Kiev, Minsk, Tashkent, Alma-Ata, and Novosibirsk. It spanned over 10,000 kilometers (6,200 mi) east to west across 11 time zones, and over 7,200 kilometers (4,500 mi) north to south. It had five climate zones: tundra, taiga, steppes, desert and mountains." +
            $"{Environment.NewLine}{Environment.NewLine}The Soviet Union had its roots in the 1917 October Revolution, when the Bolsheviks, led by Vladimir Lenin, overthrew the Russian Provisional Government which had replaced Tsar Nicholas II during World War I.In 1922, the Soviet Union was formed by a treaty which legalized the unification of the Russian, Transcaucasian, Ukrainian and Byelorussian republics.Following Lenin's death in 1924 and a brief power struggle, Joseph Stalin came to power in the mid-1920s. Stalin committed the state's ideology to Marxism–Leninism and constructed a command economy which led to a period of rapid industrialization and collectivization. During his rule, political paranoia fermented and the Great Purge removed Stalin's opponents within and outside of the party via arbitrary arrest and persecution of numerous people, resulting in at least 600,000 deaths. In 1933, a major famine struck the country, causing the deaths of three to seven million people." +
            $"{Environment.NewLine}{Environment.NewLine}Taken from: https://en.wikipedia.org/wiki/Soviet_Union";

        #region Buttons

        private void ShowMessageBoxWindow_OnClick(object sender, RoutedEventArgs e) =>
            TxtResult.Text = $"Message Box Result is: {MaterialMessageBoxWindow.Show(MessageBoxMessage)}";

        private async void ShowMessageBoxUserControl_OnClick(object sender, RoutedEventArgs e) =>
            TxtResult.Text =
                $"Message Box Result is: {await MaterialMessageBoxUserControl.ShowAsync(MessageBoxMessage).ConfigureAwait(true)}";

        private void ShowCustomMessageBoxWindow_OnClick(object sender, RoutedEventArgs e)
        {
            MaterialMessageBoxWindow materialMessageBoxWindow = new MaterialMessageBoxWindow
            {
                MessageTextBlock = { Text = MessageBoxMessage, Foreground = Brushes.Yellow },
                CopyToClipboardButton = { Visibility = Visibility.Hidden },
                OkButton = { Content = "Good", Foreground = Brushes.Yellow, Background = Brushes.LightCoral},
                CancelButton = { Content = "Bad", Foreground = Brushes.Blue, Background = Brushes.LightBlue},
                BordersGrid = { Background = Brushes.IndianRed },
                MainGrid = { Background = Brushes.Red }, BorderBrush = Brushes.DarkRed,
                BorderThickness = new Thickness(4, 4, 4, 4)
            };
            materialMessageBoxWindow.ShowDialog();
            TxtResult.Text = $"Message Box Result is: {materialMessageBoxWindow.Result}";
        }

        private async void ShowCustomMessageBoxUserControl_OnClick(object sender, RoutedEventArgs e)
        {
            MaterialMessageBoxUserControl materialMessageBoxUserControl = new MaterialMessageBoxUserControl
            {
                MessageTextBlock = { Text = MessageBoxMessage, Foreground = Brushes.Yellow },
                CopyToClipboardButton = { Visibility = Visibility.Hidden },
                OkButton = { Content = "Good", Foreground = Brushes.Yellow, Background = Brushes.LightCoral },
                CancelButton = { Content = "Bad", Foreground = Brushes.Blue, Background = Brushes.LightBlue },
                BordersGrid = { Background = Brushes.IndianRed },
                MainGrid = { Background = Brushes.Red },
                BorderBrush = Brushes.DarkRed,
                BorderThickness = new Thickness(4, 4, 4, 4)
            };
            await DialogHost.Show(materialMessageBoxUserControl).ConfigureAwait(true);
            TxtResult.Text = $"Message Box Result is: {materialMessageBoxUserControl.Result}";
        }

        private void ShowErrorMessageBoxWindow_OnClick(object sender, RoutedEventArgs e) =>
            TxtResult.Text =
                $"Message Box Result is: {MaterialMessageBoxWindow.ShowError(MessageBoxMessage, true, true)}";

        private async void ShowErrorMessageBoxUserControl_OnClick(object sender, RoutedEventArgs e) =>
            TxtResult.Text =
                $"Message Box Result is: {await MaterialMessageBoxUserControl.ShowErrorAsync(MessageBoxMessage, true, true).ConfigureAwait(true)}";

        private void ShowWarningMessageBoxWindow_OnClick(object sender, RoutedEventArgs e) =>
            TxtResult.Text =
                $"Message Box Result is: {MaterialMessageBoxWindow.ShowWarning(MessageBoxMessage, true, true)}";

        private async void ShowWarningMessageBoxUserControl_OnClick(object sender, RoutedEventArgs e) =>
            TxtResult.Text =
                $"Message Box Result is: {await MaterialMessageBoxUserControl.ShowWarningAsync(MessageBoxMessage, true, true).ConfigureAwait(true)}";

        #endregion
    }
}
