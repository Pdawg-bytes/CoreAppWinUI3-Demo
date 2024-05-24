using Microsoft.UI.Xaml;
using System.Diagnostics;
using Microsoft.UI.Xaml.Controls;
using Windows.UI;
using Microsoft.UI.Xaml.Media;

namespace WinUI3UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            Debug.WriteLine("App launched!");
            Frame rootFrame = new Frame();
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
            rootFrame.Navigate(typeof(MainPage));
            rootFrame.Background = new SolidColorBrush(new Color{ A = 0, R = 0, B = 0, G = 0 });
        }
    }
}