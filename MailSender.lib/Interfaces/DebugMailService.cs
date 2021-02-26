using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Interfaces
{
    public class DebugMailService : IMailService
    {
        private IStatistic _Statistic;

        public DebugMailService(IStatistic Statistic) { _Statistic = Statistic; }
        public void SendMail(string From, string To, string Mail, string Body)
        {
            Debug.WriteLine($"Отправка письма от {From} к {To}: {Mail} - {Body}  ");
            _Statistic.MailSended();
        }
    }
}
