using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
                new PropertyMetadata("Название", OnTitleChanged));

        private static void OnTitleChanged(DependencyObject D, DependencyPropertyChangedEventArgs E)
        {

        }

        public string Title { get => (string)GetValue(TytleProperty); set => SetValue(TytleProperty, value); }

        //НАПИСАННОЕ ВЫШЕ - ЕСТЬ СВОЙСТВО ЗАВИСИМОСТИ.

        #region добавление нового элемента

        public static DependencyProperty AddNewItemCommandProperty =
            DependencyProperty.Register(
                nameof(AddNewItemCommand),
                typeof(object),
                typeof(ItemPanel),
                new PropertyMetadata(default(object)));

        [Description("$summary$")]

        public ICommand AddNewItemCommand { get => (ICommand)GetValue(AddNewItemCommandProperty); set => SetValue(AddNewItemCommandProperty, value); }

        #endregion

        #region редактирование существующего элемента

        public static DependencyProperty EditCommandProperty =
            DependencyProperty.Register(
                nameof(EditCommand),
                typeof(object),
                typeof(ItemPanel),
                new PropertyMetadata(default(object)));

        [Description("$summary$")]

        public ICommand EditCommand { get => (ICommand)GetValue(EditCommandProperty); set => SetValue(EditCommandProperty, value); }

        #endregion

        #region удаление существующего элемента

        public static DependencyProperty RemoveItemCommandProperty =
            DependencyProperty.Register(
                nameof(RemoveItemCommand),
                typeof(object),
                typeof(ItemPanel),
                new PropertyMetadata(default(object)));

        [Description("$summary$")]

        public ICommand RemoveItemCommand { get => (ICommand)GetValue(RemoveItemCommandProperty); set => SetValue(RemoveItemCommandProperty, value); }

        #endregion

        #region ItemSource - IEnumerableItemSource элементы панели

        public static DependencyProperty ItemSourceProperty =
            DependencyProperty.Register(
                nameof(ItemSource),
                typeof(IEnumerable),
                typeof(ItemPanel),
                new PropertyMetadata(default(IEnumerable)));
        
        [Description("$summary$")]

        public IEnumerable ItemSource { get => (IEnumerable)GetValue(ItemSourceProperty); set => SetValue(ItemSourceProperty, value); }

        #endregion
        
        #region SelectedItem выделенный элемент

        public static DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(object),
                typeof(ItemPanel),
                new PropertyMetadata(default(object)));

        [Description("$summary$")]

        public object SelectedItem { get => (object)GetValue(SelectedItemProperty); set => SetValue(SelectedItemProperty, value); }

        #endregion

        public ItemPanel()
        {
            InitializeComponent();
        }
    }
}
