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
    /// Логика взаимодействия для SenderEditDialog.xaml
    /// </summary>
    public partial class SenderEditDialog : Window
    {
        public SenderEditDialog()
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
         ref string Address,
         ref string Description
         )
        {
            // Создаём окно и инициализируем его свойства
            var window = new SenderEditDialog
            {
                Title = Title,
                // Так можно инициализировать свойства вложенных объектов
                SenderName = { Text = Name },
                SenderAddress = { Text = Address },
                SenderDescription = { Text = Description },
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
            Name = window.SenderName.Text;
            Address = window.SenderAddress.Text;            
            return true;
        }

        public static bool Create(
         out string Name,
         out string Address,         
         out string Description
         )
        {
            // Инициализируем переменные значениями на случай отмены операции
            Name = null;
            Address = null;
            
            Description = null;
            
            return ShowDialog("Создать отправителя",
            ref Name,
            ref Address,            
            ref Description);
        }
    }
}
