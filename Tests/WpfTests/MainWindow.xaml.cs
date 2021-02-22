using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace WpfTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MainWindow.MaxHeightProperty = 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var from = new MailAddress(LoginEdit.Text);
            //var to = new MailAddress(AddressEdit.Text);

            //var message = new MailMessage(from, to);
            //message.Subject = ThemeName.Text;
            //message.Body = TextMessage.Text;

            //var client = new SmtpClient(ServerEdit.Text, Convert.ToInt32(PortEdit.Text));
            //client.EnableSsl = true;
            //client.Timeout = 3000;

            //client.Credentials = new NetworkCredential
            //{
            //    UserName = LoginEdit.Text,
            //    SecurePassword = PasswordEdit.SecurePassword
            //};

            //try
            //{
            //    client.Send(message);

            //    MessageBox.Show("Почта успешно отправлена!", "Отправка почты", MessageBoxButton.OK, MessageBoxImage.Information);

            //}
            //catch (SmtpException)
            //{
            //    MessageBox.Show("Ошибка авторизации", "Ошибка отправки почты", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            //catch (TimeoutException)
            //{
            //    MessageBox.Show("Ошибка адреса сервера", "Ошибка отправки почты", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
