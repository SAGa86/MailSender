using MailSender.lib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTests.Models;

namespace WpfTests.Data
{
    internal static class TestData
    {
        //public static List<Server> Servers { get; } = Enumerable.Range(1, 10)
        //    .Select(i => new Server 
        //    {
        //        Name = $"Сервер - {i}",
        //        Address = $"smtp.server{i}.com",
        //        Login = $"Login - {i}",
        //        Password = TextEncoder.Encode($"Password-{i}", 7),
        //        UseSSL = i % 2 == 0,
        //    })
        //    .ToList();
        public static IList<Server> Servers { get; } = new List<Server>
         {
             new Server
             {
                 Id = 1,
                 Name = "Яндекс",
                 Address = "smtp.yandex.ru",
                 //Port = 25,
                 UseSSL = true,
                 Login = "saga28121986@yandex.ru",
                 Password = "PassWord",
             },
             new Server
             {
                 Id = 2,
                 Name = "Мэйлру",
                 Address = "smtp.mail.ru",
                 //Port = 465,
                 UseSSL = true,
                 Login = "slay_ag@mail.ru",
                 Password = "PassWord",
             },
         };


        //public static List<Sender> Senders { get; } = Enumerable.Range(1, 10)
        //    .Select(i => new Sender
        //    {
        //        Name = $"Отправитель - {i}",
        //        Address = $"sender_{i}@server.com",              
        //    })
        //    .ToList();

        public static IList<Sender> Senders { get; } = new List<Sender>
         {
             new Sender
             {
                 Id = 1,
                 Name = "Гавриленко А.Ю.",
                 Address = "slay_ag@mail.ru",
                 Description = "Почта от Гавриленко"
             },
             new Sender
             {
                 Id = 2,            
                 Name = "Гавриленко А.Ю. №2",
                 Address = "saga281286@yandex.ru",
                 Description = "Почта от Гавриленко(резерв)"
             },             
         };


        //public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 10)
        //   .Select(i => new Recipient
        //   {
        //       Name = $"Получатель - {i}",
        //       Address = $"recipient_{i}@server.com",
        //   })
        //   .ToList();

        public static IList<Recipient> Recipients { get; } = new List<Recipient>
         {
         new Recipient
             {
                 Id = 1,
                 Name = "Гавриленко А.Ю.",
                 Address = "slay_ag@mail.ru",
                 Description = "Почта от Гавриленко"
             },
         new Recipient
             {
                 Id = 2,
                 Name = "Гавриленко А.Ю. №2",
                 Address = "saga281286@yandex.ru",
                 Description = "Почта от Гавриленко(резерв)"
             },
         
         };


        public static List<Message> Messages { get; } = Enumerable.Range(1, 10)
           .Select(i => new Message
           {
               Title = $"Тема - {i}",
               Body = $"Текст сообщения {i}",
           })
           .ToList();
    }
}
