using MailSender.lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib
{
    public class DebugMailService : IMailService
    {
        public IMailSender GetSender(string Server, int Port, bool SSL, string Login, string Password)
        {
            return new DebugMailSender(Server, Port, SSL, Login, Password);
        }
    }

    internal class DebugMailSender : IMailSender
    {
        private string _Server;
        private int _Port;
        private bool _SSL;
        private string _Login;
        private string _Password;

        public DebugMailSender(string server, int port, bool SSL, string login, string password)
        {
            _Server = server;
            _Port = port;
            _SSL = SSL;
            _Login = login;
            _Password = password;
        }

        public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            Debug.WriteLine("Отправка почты...");
        }
    }
}
