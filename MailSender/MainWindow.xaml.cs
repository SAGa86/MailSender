using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MailSender
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
                
        private void OpenFIleMenu_Click(object sender, RoutedEventArgs e)
        {
            var open_dialog = new OpenFileDialog
            {
                Filter = "Excel (*.xls)|*.xls|Все файлы (*.*)|*.*",
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Выбор файла для чтения"
            };

            if (open_dialog.ShowDialog() != true) return;

            var file_name = open_dialog.FileName;

            if (!File.Exists(file_name)) return;

        }
    }
}
