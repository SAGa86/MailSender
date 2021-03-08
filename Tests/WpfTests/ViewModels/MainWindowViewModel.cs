using MailSender.lib.Commands;
using MailSender.lib.Interfaces;
using MailSender.lib.ViewModels.Base;

using System.Collections.ObjectModel;

using System.Windows.Input;

using WpfTests.Infrastructure.Services;

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

        #region SelectedServer: Выбранный сервер

        private Server _SelectedServer;

        public Server SelectedServer { get => _SelectedServer; set => Set(ref _SelectedServer, value); }

        #endregion

        #region SelectedRecipient: Выбранный получатель

        private Recipient _SelectedRecipient;

        public Recipient SelectedRecipient { get => _SelectedRecipient; set => Set(ref _SelectedRecipient, value); }

        #endregion

        #region SelectedSender: Выбранный отправитель

        private Sender _SelectedSender;

        public Sender SelectedSender { get => _SelectedSender; set => Set(ref _SelectedSender, value); }

        #endregion

        #region SelectedMessage: Выбранное сообщение

        private Message _SelectedMessage; 

        public Message SelectedMessage { get => _SelectedMessage; set => Set(ref _SelectedMessage, value); }

        #endregion

        private ICommand _LoadDataCommand;

        public ICommand LoadDataCommand => _LoadDataCommand
            ?? new LambdaCommand(OnLoadDataCommand, CanLoadDataCommandExecute);

        private bool CanLoadDataCommandExecute(object p) => Servers.Count == 0;

        private void OnLoadDataCommand(object p) { LoadData(); }

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

        private void LoadData() 
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
