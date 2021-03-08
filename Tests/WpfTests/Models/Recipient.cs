using System;
using WpfTests.Models.Base;

namespace WpfTests.Models
{
    public class Recipient : Entity

    {
        //public int Id { get; set; }
        private string _Name;

        public string Name 
        { 
            get => _Name;

            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Не задано имя!");
                _Name = value; 
            }
        }

        public string Address { get; set; }
        public string Description { get; set; }
    }
}
