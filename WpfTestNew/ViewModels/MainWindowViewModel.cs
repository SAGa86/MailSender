using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.ViewModels.Base;

namespace WpfTestNew.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Test111";
        public string Title {
            get => _Title;
            set => Set(ref _Title, value);
            
        }

    }
}
