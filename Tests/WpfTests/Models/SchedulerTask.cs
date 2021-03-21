using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTests.Models.Base;

namespace WpfTests.Models
{
    public class SchedulerTask : Entity

    {
        public DateTime Time { get; set; }
        public Server Server { get; set; }
        public Sender Sender { get; set; }
        public List<Recipient> Recipients { get; set; }
        public Message Message { get; set; }
    }
}
