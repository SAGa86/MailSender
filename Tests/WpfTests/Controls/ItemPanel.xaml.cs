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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTests.Controls
{
    /// <summary>
    /// Логика взаимодействия для ItemPanel.xaml
    /// </summary>
    public partial class ItemPanel : UserControl
    {
        public static readonly DependencyProperty TytleProperty =
            DependencyProperty.Register(
                nameof(Title),
                typeof(string),
                typeof(ItemPanel),
                new PropertyMetadata(default(string)));
       
        public string Title { get => (string)GetValue(TytleProperty); set => SetValue(TytleProperty, value); }

        //НАПИСАННОЕ ВЫШЕ - ЕСТЬ СВОЙСТВО ЗАВИСИМОСТИ.
        public ItemPanel()
        {
            InitializeComponent();
        }
    }
}
