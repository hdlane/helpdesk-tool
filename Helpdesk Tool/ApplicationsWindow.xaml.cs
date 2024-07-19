using System.Windows;

namespace Helpdesk_Tool
{
    /// <summary>
    /// Interaction logic for ApplicationsWindow.xaml
    /// </summary>
    public partial class ApplicationsWindow : Window
    {
        public ApplicationsWindow()
        {
            InitializeComponent();
        }

        public ApplicationsWindow(string computername, string applications)
        {
            InitializeComponent();
            computerTextBox.Text = "Applications Installed On " + computername;
            applicationsTextBox.Text = applications;
        }
    }
}
