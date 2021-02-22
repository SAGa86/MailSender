﻿using MailSender.lib.Service;
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
        public static List<Server> Servers { get; } = Enumerable.Range(1, 10)
            .Select(i => new Server 
            {
                Name = $"Сервер - {i}",
                Address = $"smtp.server{i}.com",
                Login = $"Login - {i}",
                Password = TextEncoder.Encode($"Password-{i}", 7),
                UseSSL = i % 2 == 0,
            })
            .ToList();

        public static List<Sender> Senders { get; } = Enumerable.Range(1, 10)
            .Select(i => new Sender
            {
                Name = $"Отправитель - {i}",
                Address = $"sender_{i}@server.com",              
            })
            .ToList();

        public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 10)
           .Select(i => new Recipient
           {
               Name = $"Получатель - {i}",
               Address = $"recipient_{i}@server.com",
           })
           .ToList();

        public static List<Message> Messages { get; } = Enumerable.Range(1, 10)
           .Select(i => new Message
           {
               Title = $"Тема - {i}",
               Body = $"Текст сообщения {i}",
           })
           .ToList();
    }
}
