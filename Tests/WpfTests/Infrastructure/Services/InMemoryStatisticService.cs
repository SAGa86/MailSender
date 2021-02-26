using MailSender.lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTests.Data;

namespace WpfTests.Infrastructure.Services
{
    internal class InMemoryStatisticService : IStatistic
    {
        private int _SendedMailsCount;
        public int SendedMailsCount => _SendedMailsCount;
        public void MailSended() => _SendedMailsCount++;

        public int SendersCount => TestData.Senders.Count;

        public int RecipientsCount => TestData.Recipients.Count;
        private readonly Stopwatch _StopwatchTimer = Stopwatch.StartNew();
        public TimeSpan UpTime => _StopwatchTimer.Elapsed;

        
    }
}
