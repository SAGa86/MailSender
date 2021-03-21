using System.Collections.Generic;
using WpfTests.Models;

namespace WpfTests.Infrastructure.Services.InMemory
{
    class RecipientsRepository : RepositoryInMemory<Recipient>
    {
        
        public RecipientsRepository() : base(new List<Recipient>
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
         })
        {

        }

        public override void Update(Recipient item)
        {
            
            var db_item = GetById(item.Id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;           
            db_item.Description = item.Description;            
        }

    }
}

