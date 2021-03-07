using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTests.Models;
using WpfTests.Infrastructure.Services.InMemory;
using System.Windows.Documents;

namespace WpfTests.Infrastructure.Services.InMemory
{
    class ServersRepository : RepositoryInMemory<Server>
    {
        //private static List<Server> _Servers;

        //private int _MaxId;

        public ServersRepository() : base(new List<Server>
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
             })
        {

        }

        public override void Update(Server item)
        {
            //if (_Servers.Contains(item))
            //    return;
            var db_item = GetById(item.Id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Login = item.Login;
            db_item.Password = item.Password;
            db_item.Description = item.Description;
            db_item.Port = item.Port;
        }

    }
}
