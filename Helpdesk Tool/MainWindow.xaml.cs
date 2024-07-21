using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Net.Http;
using System.Text.Json;

namespace HelpdeskTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class ComputersDataTable : DataTable
        {
            private string Url = "http://127.0.0.1:5000/";
            private static ComputersDataTable? instance;
            public string? Json { get; set; }
            public DataTable? Dt { get; set; }
            private ComputersDataTable()
            {
                Json = GetJsonAsync(Url).Result;
                Dt = GetDataTableFromJson();
            }

            public static ComputersDataTable GetInstance()
            {
                if (instance == null)
                {
                    instance = new ComputersDataTable();
                }
                return instance;
            }
            public async Task<string> GetJsonAsync(string url)
            {
                using var client = new HttpClient();
                try
                {
                    using HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                catch (Exception ex)
                {
                    return "";
                }
            }

            public DataTable GetDataTableFromJson()
            {
                DataTable? dataTable = new DataTable();
                if (string.IsNullOrWhiteSpace(Json))
                {
                    return dataTable;
                }

                var dataArray = JsonSerializer.Deserialize<JsonElement[]>(Json);

                foreach (var property in dataArray[0].EnumerateObject())
                {
                    dataTable.Columns.Add(property.Name);
                }
                foreach (var obj in dataArray)
                {
                    var objProperties = obj.EnumerateObject();
                    DataRow newRow = dataTable.NewRow();
                    foreach (var item in objProperties)
                    {
                        newRow[item.Name] = item.Value.ToString();
                    }
                    dataTable.Rows.Add(newRow);
                }
                return dataTable;
            }

            public void UpdateDataTableAsync()
            {
                Json = GetJsonAsync(Url).Result;
                Dt = GetDataTableFromJson();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComputersDataTable computersDataTable = ComputersDataTable.GetInstance();
            computersDataGrid.ItemsSource = computersDataTable.Dt.DefaultView;
            filterTextBox.Focus();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            return;
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.computersDataGrid.SelectedItem != null)
            {
                DataRowView drv = (DataRowView)computersDataGrid.SelectedItem;
                string computername = (drv["ComputerName"]).ToString();

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow= false;
                startInfo.UseShellExecute= true;
                startInfo.FileName = @"C:\Windows\System32\msra.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.Arguments = "/offerra " + computername;

                Process.Start(startInfo);

            } else
            { 
                filterTextBox.Focus();
            }
        }
        private void msraButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo msraStartInfo = new ProcessStartInfo();
            msraStartInfo.CreateNoWindow = false;
            msraStartInfo.UseShellExecute = true;
            msraStartInfo.FileName = @"C:\Windows\System32\msra.exe";
            msraStartInfo.WindowStyle = ProcessWindowStyle.Normal;
            msraStartInfo.Arguments = "/offerra";

            Process.Start(msraStartInfo);
        }

        private void rdpButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo rdpStartInfo = new ProcessStartInfo();
            rdpStartInfo.CreateNoWindow = false;
            rdpStartInfo.UseShellExecute = true;
            rdpStartInfo.FileName = @"C:\Windows\System32\mstsc.exe";
            rdpStartInfo.WindowStyle = ProcessWindowStyle.Normal;

            Process.Start(rdpStartInfo);
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ComputersDataTable computersDataTable = ComputersDataTable.GetInstance();
            DataView computersDataView = computersDataTable.Dt.DefaultView;
            computersDataView.RowFilter = 
                "ComputerName LIKE '%" + filterTextBox.Text + 
                "%' OR UserName LIKE '%" + filterTextBox.Text + "%'";
            computersDataGrid.ItemsSource = computersDataView;
            computersDataGrid.SelectedIndex = 0;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            this.filterTextBox.Clear();
            this.filterTextBox.Focus();
            computersDataGrid.SelectedItem = null;
            connectButton.IsEnabled = false;
        }

        private void computersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.computersDataGrid.SelectedItem == null)
            {
                connectButton.IsEnabled = false;
            }
            else
            {
                connectButton.IsEnabled = true;
            }
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            ComputersDataTable computersDataTable = ComputersDataTable.GetInstance();
            computersDataTable.UpdateDataTableAsync();
            if (computersDataTable.Dt.Rows.Count == 0)
            {
                refreshTextBox.Text = "No data available";
            }
            else
            {
                var currentTime = DateTime.Now;
                refreshTextBox.Text = $"Last refresh: {currentTime}";
            }

            DataView computersDataView = computersDataTable.Dt.DefaultView;
            computersDataGrid.ItemsSource = computersDataView;
            computersDataGrid.SelectedIndex = 0;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

    }
}