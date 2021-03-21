using System;
using System.ComponentModel;
using WpfTests.Models.Base;

namespace WpfTests.Models
{
    public class Recipient : Entity, IDataErrorInfo

    {
        
        private string _Name;

        public string this[string columnName] => throw new NotImplementedException();



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
               
        string IDataErrorInfo.Error => null;
        string IDataErrorInfo.this[string PropertyName]
        {

        get
        {
            switch (PropertyName)
           {
                default: return null;

                case nameof(Name):
                    var name = Name;

                    if (name is null) return "Имя не может быть пустой ссылкой";
                    if (name.Length < 3) return "Имя не может быть слишком коротким (менее трех символов)";
                    if (name.Length > 20) return "Имя не может быть слишком длинным (более 20 символов)";

                    return null;
            }

        }
}


    }
}
