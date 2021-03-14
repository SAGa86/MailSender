using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace SyncVsAsyncWPF
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       /* static Task<int> MethodAsync(int x)
        {
            int result = 1;

            return Task.Run(() =>
            {
                Thread.Sleep(10000);
                result = x * x;
                return result;
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
            {
                    int num = 5;
                    label.Content = MethodSync(num).ToString();
            }

        static int MethodSync(int x)
        {
            int result = 1;

            Thread.Sleep(10000);
            result = x * x;
            return result;
        }
       */
    }
}


