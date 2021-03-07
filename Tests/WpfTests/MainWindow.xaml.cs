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
using MailSender.lib.ViewModels;
using WpfTests.ViewModels;

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
            //DataContext = new MainWindowViewModel() 
             
        }
        

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
            ServersList.SelectedItem = server;
        }

        private void OnDeleteServerButtonClick(object Sender, RoutedEventArgs E)
        {
            if (!(ServersList.SelectedItem is Server server)) return;
            TestData.Servers.Remove(server);
            ServersList.ItemsSource = null;
            ServersList.ItemsSource = TestData.Servers;
            ServersList.SelectedItem = TestData.Servers.FirstOrDefault();
        }
          
       
                      
        private void OnAddSenderButtonClick(object Sender, RoutedEventArgs E)
        {
            if (!SenderEditDialog.Create(
            out var name,
            out var address,            
            out var description
            ))
                return;
            var sender = new Sender
            {
                Id = TestData.Senders.DefaultIfEmpty().Max(s => s.Id) + 1,
                Name = name,
                Address = address,                
                Description = description                
            };
            TestData.Senders.Add(sender);
            SendersList.ItemsSource = null;
            SendersList.ItemsSource = TestData.Senders;
            SendersList.SelectedItem = sender;
        }

        private void OnEditSenderButtonClick(object Sender, RoutedEventArgs E)
        {
            if (!(SendersList.SelectedItem is Sender sender)) return;
            var name = sender.Name;
            var address = sender.Address;            
            var description = sender.Description;
            
            if (!SenderEditDialog.ShowDialog("Редактирование отправителя",
            ref name,
            ref address,
            ref description))
                return;
            sender.Name = name;
            sender.Address = address;
            sender.Description = description;
            SendersList.ItemsSource = null;
            SendersList.ItemsSource = TestData.Senders;
            SendersList.SelectedItem = sender;
        }

        private void OnDeleteSenderButtonClick(object Sender, RoutedEventArgs E)
        {
            if (!(SendersList.SelectedItem is Sender sender)) return;
            TestData.Senders.Remove(sender);
            SendersList.ItemsSource = null;
            SendersList.ItemsSource = TestData.Senders;
            SendersList.SelectedItem = TestData.Senders.FirstOrDefault();
        }

        private void OnSendNowButtonClick(object sender, RoutedEventArgs e)
        {
            //if (!(SendersList.SelectedItem is Sender Sender)) return;
            //if (!(RecipientsList.SelectedItem is Recipient Recipient)) return;
            //if (!(ServersList.SelectedItem is Server Server)) return;
            //if (!(MessagesList.SelectedItem is Message Message)) return;
            //// Если одни из параметров невозможно получить, то выходим
            //// Создаём объект-рассыльщик и заполняем параметры сервера
            //var mail_sender = new SmtpSender(Server.Address, Server.Port, Server.UseSSL, Server.Login, Server.Password);
            //// При отправке почты может возникнуть проблема. Ставим перехват исключения.
            //try
            //{
            //    // Запускаем таймер
            //    var timer = Stopwatch.StartNew();
            //    // И запускаем процесс отправки почты
            //    mail_sender.Send(
            //    Sender.Address, Recipient.Address,
            //    Message.Title, Message.Body);
            //    timer.Stop(); // По завершении останавливаем таймер
            //                  // Если почта успешно отправлена, то отображаем диалоговое окно
            //    MessageBox.Show(
            //    $"Почта успешно отправлена за {timer.Elapsed.TotalSeconds:0.##}c",
            //    "Отправка почты",
            //    MessageBoxButton.OK,
            //    MessageBoxImage.Information);
            }
            // Если случилась ошибка, то перехватываем исключение
            //catch (SmtpException) // Перехватывает строго нужное нам исключение!
            //{
            //    MessageBox.Show(
            //    "Ошибка при отправке почты",
            //    "Отправка почты",
            //    MessageBoxButton.OK,
            //    MessageBoxImage.Error);
            //
        //}

        //}
    }
}
