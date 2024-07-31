using System.Windows;

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
            endpointServerUrl.Text = Helpdesk_Tool.Properties.Settings.Default.Server;
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
                Helpdesk_Tool.Properties.Settings.Default.Server = endpointServerUrl.Text;
                Helpdesk_Tool.Properties.Settings.Default.Save();
                settingsSaveTextBlock.Text = $"URL Saved: {endpointServerUrl.Text}";
                cancelButton.Content = "Close";
            }
        }
    }
}
