using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            var from = new MailAddress("slay_ag@mail.ru", "Alex");
            // кому отправляем
            var to = new MailAddress("saga281286@yandex.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "ТестОтправки";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            var client = new SmtpClient("smtp.mail.ru", 25);
            // логин и пароль
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential
            {
                UserName = "slay_ag@mail.ru",
                Password = "%%%"
            };
            
            client.Send(m);
            Console.Read();
        }
    }
}
