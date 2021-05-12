using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClient.Services;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RngService _rngService = new();
        private readonly UserAccountService _userAccountService = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RngButton_Click(object sender, MouseButtonEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            MessageBox.Show(_userAccountService.GetUsers());
            watch.Stop();
        }

        private void TestButton_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Test button clicked.");
        }

        private async void RngAsyncButton_Click(object sender, MouseButtonEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var integers = await _rngService.GetRandomIntegers();

            watch.Stop();
            MessageBox.Show($"{string.Join("\n", integers)} execution time: {watch.ElapsedMilliseconds} ms");
        }
    }
}