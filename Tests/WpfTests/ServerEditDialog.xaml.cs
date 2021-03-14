using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfTests
{
    /// <summary>
    /// Логика взаимодействия для ServerEditDialog.xaml
    /// </summary>
    public partial class ServerEditDialog : Window
    {
        public ServerEditDialog()
        {
            InitializeComponent();
        }
        private void OnPortTextInput(object Sender, TextCompositionEventArgs E)
        {
            // Если источник события - не текстовое поле ввода
            // или текст в поле ввода отсутствует, то...
            // ничего не делаем
            if (!(Sender is TextBox text_box) || text_box.Text == "") return;
            // иначе если не удалось превратить текст в число, то
            // отмечаем событие как обработанное - текст не введётся
            E.Handled = !int.TryParse(text_box.Text, out _);
        }
        private void OnButtonClick(object Sender, RoutedEventArgs E)
        {
            DialogResult = !((Button)E.OriginalSource).IsCancel;
            Close();
        }
        public static bool ShowDialog(
         string Title, ref string Name,
         ref string Address, ref int Port, ref bool UseSSL,
         ref string Description,
         ref string Login, ref string Password)
        {
            // Создаём окно и инициализируем его свойства
            var window = new ServerEditDialog
            {
                Title = Title,
                // Так можно инициализировать свойства вложенных объектов
                ServerName = { Text = Name },
                ServerAddress = { Text = Address },
                ServerPort = { Text = Port.ToString() },
                ServerSSL = { IsChecked = UseSSL },
                Login = { Text = Login },
                Password = { Password = Password },
                
            ServerDescription = { Text = Description },
                // Берём класс "Приложение"
                Owner = Application
            // получаем экземпляр текущего приложения
            .Current
            // берём все окна приложения
            .Windows
            // пеерводим их из интерфейса IEnumerable в IEnumerable<Window>
            .Cast<Window>()
            // находим первое окно, у которого свойство IsActive == true
            .FirstOrDefault(window => window.IsActive)
            };
            if (window.ShowDialog() != true) return false;
            Name = window.ServerName.Text;
            Address = window.ServerAddress.Text;
            Port = int.Parse(window.ServerPort.Text);
            Login = window.Login.Text;
            Password = window.Password.Password;
            return true;
        }

        public static bool Create(
         out string Name,
         out string Address,
         out int Port,
         out bool UseSSL,
         out string Description,
         out string Login,
         out string Password)
        {
            // Инициализируем переменные значениями на случай отмены операции
            Name = null;
            Address = null;
            Port = 25;
            UseSSL = false;
            Description = null;
            Login = null;
            Password = null;
            return ShowDialog("Создать сервер",
            ref Name,
            ref Address,
            ref Port,
            ref UseSSL,
            ref Description,                   
            ref Login,
            ref Password);
        }


    }
}
