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
            MailAddress from = new MailAddress("slay_ag@mail.com", "Alex");
            // кому отправляем
            MailAddress to = new MailAddress("saga281286@yandex.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "ТестОтправки";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.com", 465);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("slay_ag@mail.ru", "Bastardsaints96");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();
        }
    }
}
