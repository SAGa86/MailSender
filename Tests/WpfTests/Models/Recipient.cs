using WpfTests.Models.Base;

namespace WpfTests.Models
{
    public class Recipient : Entity

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
