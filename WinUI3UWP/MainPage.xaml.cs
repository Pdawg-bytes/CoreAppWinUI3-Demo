using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WinUI3UWP
{
    public sealed partial class MainPage : Page
    {
        int clicks = 0;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            MyButton.Content = $"Clicked {clicks} times.";
        }
    }
}