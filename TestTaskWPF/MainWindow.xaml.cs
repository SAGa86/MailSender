using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TestTaskWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private CancellationTokenSource _CalculationConcellation;

        private async void StartButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            button.IsEnabled = false;
            CancelButton.IsEnabled = true;

            var cancellation = new CancellationTokenSource();
            _CalculationConcellation = cancellation;
            var progress = new Progress<double>(
                value =>
                {
                    ProgressInformer.Value = value;
                    PersentBlock.Text = value.ToString("p");
                });
            //var thread_Id = Thread.CurrentThread.ManagedThreadId;
            //var result = await Task.Run(() =>IntSum(500)).ConfigureAwait(true);
            //var thread_Id2 = Thread.CurrentThread.ManagedThreadId;

            try
            {

                var result = await Task.Run(() => IntSumAsync(500, progress, cancellation.Token))
                    .ConfigureAwait(true);

                ((IProgress<double>)progress).Report(0);

                
                ResultTextBlock.Text = result.ToString();
            }

            catch (OperationCanceledException)
            {
                ResultTextBlock.Text = "Операция отменена";
                ((IProgress<double>)progress).Report(0);
            }

            button.IsEnabled = true;
            CancelButton.IsEnabled = false;

        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            _CalculationConcellation?.Cancel();
        }

        private static long IntSum(long x)
        {
            //var thread_Id = Thread.CurrentThread.ManagedThreadId;
            if (x < 0) return IntSum(-x);

            var result = 0l;

            while (x > 0)
            {
                result += x;
                x--;

                Thread.Sleep(10);
            }

            return result;
        }

        private static async Task<long> IntSumAsync(
            long X, 
            IProgress<double> Progress = default, 
            CancellationToken Cancel = default)
        {
            Cancel.ThrowIfCancellationRequested();
            //var thread_Id = Thread.CurrentThread.ManagedThreadId;
            if (X < 0) return await IntSumAsync(-X).ConfigureAwait(false);

            var result = 0l;
            var x = 1;

            while (x <= X)
            {
                if (Cancel.IsCancellationRequested)
                {
                    //подготовка к отмене, чистка ресурсов
                    Cancel.ThrowIfCancellationRequested();
                }

                

                result += x;
                x++;

                Progress?.Report((double) x / X);

                await Task.Delay(10, Cancel).ConfigureAwait(false);
                //Thread.Sleep(10);
            }

            return result;
        }
    }
}
