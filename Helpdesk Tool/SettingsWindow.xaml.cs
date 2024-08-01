using System.Windows;
using HelpdeskTool;

namespace Helpdesk_Tool
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            MainWindow.Settings Settings = MainWindow.Settings.GetInstance();
            string? Server = Settings.Server;
            endpointServerUrl.Text = Server;
            cancelButton.Content = "Cancel";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (endpointServerUrl.Text != null)
            {
                MainWindow.Settings Settings = MainWindow.Settings.GetInstance();
                Settings.Server = endpointServerUrl.Text;
                settingsSaveTextBlock.Text = $"URL Saved: {endpointServerUrl.Text}";
                cancelButton.Content = "Close";
            }
        }
    }
}
