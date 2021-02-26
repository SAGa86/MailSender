using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTests.Models;

namespace WpfTests.Infrastructure
{
    class ServersRepository
    {
        private static IList<Server> _Servers;

        public ServersRepository()
        { 
             _Servers = new List<Server> 
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
                     Password = "Bastard_saints96",
                 },
             };
        }

        public IEnumerable<Server> GetAll() => _Servers;

        public void Add(Server server)
        {
            _Servers.Add(server);
        }

        public void Remove (Server server)
        {
            _Servers.Remove(server);
        }
    }
}
