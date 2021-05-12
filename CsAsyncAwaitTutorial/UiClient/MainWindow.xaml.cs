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
using UiClient.Services;

namespace UiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RngService _rngService = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RngButton_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var integers = _rngService.GetRandomIntegersSync();

            watch.Stop();
            MessageBox.Show($"Generated integers:\n\t{string.Join("\n\t", integers)}\n Execution time: {watch.ElapsedMilliseconds} ms");
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test button clicked.");
        }

        private async void RngAsyncButton_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var integers = await _rngService.GetRandomIntegersAsync();

            watch.Stop();
            MessageBox.Show($"Generated integers:\n\t{string.Join("\n\t", integers)}\n Execution time: {watch.ElapsedMilliseconds} ms");
        }

        private async void RngAsyncParallelButton_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var integers = await _rngService.GetRandomIntegersAsyncParallel();

            watch.Stop();
            MessageBox.Show($"Generated integers:\n\t{string.Join("\n\t", integers)}\n Execution time: {watch.ElapsedMilliseconds} ms");
        }
    }
}
