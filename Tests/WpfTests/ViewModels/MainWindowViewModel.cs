using MailSender.lib.Commands;
using MailSender.lib.Interfaces;
using MailSender.lib.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfTests.Infrastructure;
using WpfTests.Infrastructure.Services.InMemory;
using WpfTests.Models;

namespace WpfTests.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly ServersRepository _Servers;
        private readonly IMailService _MailService;
        private string _Title = "Рассыльщик";
        public string Title { get => _Title; set => Set(ref _Title, value); }
        private string _Status = "Готов!";
        public string Status { get => _Status; set => Set(ref _Status, value); }

        public ObservableCollection<Server> Servers { get; } = new ();

        public ObservableCollection<Sender> Senders { get; } = new();

        public ObservableCollection<Recipient> Recipients { get; } = new();


        public ObservableCollection<Message> Messages { get; } = new();

        #region Команды
        private ICommand _LoadServersCommand;

        public ICommand LoadServersCommand => _LoadServersCommand
            ?? new LambdaCommand(OnLoadServersCommand, CanLoadServerCommandExecute);

        private bool CanLoadServerCommandExecute(object p) => Servers.Count == 0;

        private void OnLoadServersCommand(object p) { LoadServers(); }

        private ICommand _SendEmailCommand;

        public ICommand SendEmailCommand => _SendEmailCommand
            ?? new LambdaCommand(OnSendEmailCommand, CanSendEmailCommandExecute);

        private bool CanSendEmailCommandExecute(object p) => Servers.Count == 0;

        private void OnSendEmailCommand(object p) { _MailService.SendMail("Иванов", "Петров", "Тема", "Текст"); }

        #endregion
        public MainWindowViewModel(ServersRepository Servers, IMailService MailService)
        { 
            _Servers = Servers;
            _MailService = MailService;
        }

        private void LoadServers() 
        {
            foreach (var server in _Servers.GetAll())
                Servers.Add(server);
        }
    }
}
