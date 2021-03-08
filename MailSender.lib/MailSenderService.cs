using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib
{
    /*public class MailSenderService
    {
        public string ServerAddress { get; set; }

        public int ServerPort { get; set; }

        public bool UseSSL { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public void SendMessage(string SenderAddress,string RecipientAddress, string Subject, string Body)
        {
            var from = new MailAddress(SenderAddress);
            var to = new MailAddress(RecipientAddress);

            using var message = new MailMessage(from, to)
            {
                Subject = Subject,
                Body = Body
            };

            using var client = new SmtpClient(ServerAddress, ServerPort)
            {
                EnableSsl = UseSSL,
                Credentials = new NetworkCredential
                {
                    UserName = Login,
                    Password = Password
                }

            };

            client.Send(message);
        }*/ 
       public class SmtpSender
        {
            private readonly string _Address;
            private readonly int _Port;
            private readonly bool _UseSsl;
            private readonly string _Login;
            private readonly string _Password;
            public SmtpSender(
            string Address, int Port, bool UseSSL,
            string Login, string Password)
            {
                _Address = Address;
                _Port = Port;
                _UseSsl = UseSSL;
                _Login = Login;
                _Password = Password;
            }

            //var from = new MailAddress(SenderAddress);
            //var to = new MailAddress(RecipientAddress);

            public void Send(
            string From, string To,
            string Title, string Message)
            {
                var message = new MailMessage(From, To)
                 {
                 Subject = Title,
                 Body = Message
                 };
                var client = new SmtpClient(_Address, _Port)
                {
                    EnableSsl = _UseSsl,
                    Credentials = new NetworkCredential(_Login, _Password)
                };
                client.Send(message);
            }
        }
    //}
}
