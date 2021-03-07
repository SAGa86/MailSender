using WpfTests.Models.Base;

namespace WpfTests.Models
{
    public class Server : Entity 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Port { get; set; } = 25;
        public bool UseSSL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }

        //public override string ToString() => $"{Name}:{Port}";
       

    }
}
