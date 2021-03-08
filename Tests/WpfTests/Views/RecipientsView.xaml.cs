using System.Windows.Controls;


namespace WpfTests.Views
{
    /// <summary>
    /// Логика взаимодействия для RecipientsView.xaml
    /// </summary>
    public partial class RecipientsView : UserControl
    {
        public RecipientsView()
        {
            InitializeComponent();
        }

        private void OnNameValidationError (object? Sender, ValidationErrorEventArgs E )
        {

        }
    }
}
