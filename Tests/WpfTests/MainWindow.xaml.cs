using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WpfTests.Models;
using MailSender.lib;
using WpfTests.Data;

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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
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
        //}

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnAddServerButtonClick(object Sender, RoutedEventArgs E)
        {
            if (!ServerEditDialog.Create(
            out var name,
            out var address,
            out var port,
            out var ssl,
            out var description,
            out var login,
            out var password))
                return;
            var server = new Server
            {
                Id = TestData.Servers.DefaultIfEmpty().Max(s => s.Id) + 1,
                Name = name,
                Address = address,
                Port = port,
                UseSSL = ssl,
                Description = description,
                Login = login,                
            Password = password
            };
            TestData.Servers.Add(server);
            ServersList.ItemsSource = null;
            ServersList.ItemsSource = TestData.Servers;
            ServersList.SelectedItem = server;
        }

        private void OnEditServerButtonClick(object Sender, RoutedEventArgs E)
        {
            if (!(ServersList.SelectedItem is Server server)) return;
            var name = server.Name;
            var address = server.Address;
            var port = server.Port;
            var ssl = server.UseSSL;
            var description = server.Description;
            var login = server.Login;
            var password = server.Password;
            if (!ServerEditDialog.ShowDialog("Редактирование сервера",
            ref name,
            ref address, ref port, ref ssl,
            ref description,
            ref login, ref password))
                return;
            server.Name = name;
            server.Address = address;
            server.Port = port;
            server.UseSSL = ssl;
            server.Description = description;
            server.Login = login;
            server.Password = password;
            ServersList.ItemsSource = null;
            ServersList.ItemsSource = TestData.Servers;
        }

        private void OnDeleteServerButtonClick(object Sender, RoutedEventArgs E)
        {
            if (!(ServersList.SelectedItem is Server server)) return;
            TestData.Servers.Remove(server);
            ServersList.ItemsSource = null;
            ServersList.ItemsSource = TestData.Servers;
            ServersList.SelectedItem = TestData.Servers.FirstOrDefault();
        }


        private void OnSendNowButtonClick(object sender, RoutedEventArgs e)
        {
            /*// Извлекаем исходные параметры по возможности
            if (!(SendersList.SelectedItem is Sender Sender)) return;
            if (!(RecipientsList.SelectedItem is Recipient Recipient)) return;
            if (!(ServersList.SelectedItem is Server Server)) return;
            if (!(MessagesList.SelectedItem is Message Message)) return;
            // Если одни из параметров невозможно получить, то выходим
            // Создаём объект-рассыльщик и заполняем параметры сервера
            var mail_sender = new (
            Sender.Address, Recipient.Address, Server.UseSSL,
            Server.Login, Server.Password);
            // При отправке почты может возникнуть проблема. Ставим перехват исключения.
            try
            {
                // Запускаем таймер
                var timer = Stopwatch.StartNew();
                // И запускаем процесс отправки почты
                mail_sender.Send(
                Sender.Address, Recipient.Address,
                Message.Title, Message.Body);
                timer.Stop(); // По завершении останавливаем таймер
                              // Если почта успешно отправлена, то отображаем диалоговое окно
                MessageBox.Show(
                $"Почта успешно отправлена за {timer.Elapsed.TotalSeconds:0.##}c",
                "Отправка почты",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }
            // Если случилась ошибка, то перехватываем исключение
                catch (SmtpException) // Перехватывает строго нужное нам исключение!
                {
                    MessageBox.Show(
                    "Ошибка при отправке почты",
                    "Отправка почты",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                }*/
            }

        private void OnAddRecipientButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
