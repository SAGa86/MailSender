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
using WpfTests.Infrastructure.Services;
using WpfTests.Infrastructure.Services.InMemory;
using WpfTests.Models;
using WpfTests.Models.Base;

namespace WpfTests.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Server> _Servers;

        private readonly IRepository<Sender> _Senders;

        private readonly IRepository<Recipient> _Recipients;

        private readonly IRepository<Message> _Messages;

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
        public MainWindowViewModel(
            IRepository<Server> Servers,
            IRepository<Sender> Senders,
            IRepository<Recipient> Recipients,
            IRepository<Message> Messages,
            IMailService MailService)
        { 
            _Servers = Servers;
            _Senders = Senders;
            _Recipients = Recipients;
            _Messages = Messages;
            _MailService = MailService;
        }

        void Load<T> (ObservableCollection<T> collection, IRepository<T> rep) where T : Entity
        {
            collection.Clear();
            foreach (var item in rep.GetAll())
                collection.Add(item);
        }

        private void LoadServers() 
        {
            Load(Servers, _Servers);
            Load(Senders, _Senders);
            Load(Recipients, _Recipients);
            Load(Messages, _Messages);
            //foreach (var server in _Servers.GetAll())
            //    Servers.Add(server);
        }
    }
}
