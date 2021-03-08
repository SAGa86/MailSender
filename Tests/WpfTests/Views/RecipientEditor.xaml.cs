
using System.Windows.Controls;

namespace WpfTests.Views
{
    /// <summary>
    /// Логика взаимодействия для RecipientEditor.xaml
    /// </summary>
    public partial class RecipientEditor
    {
        public RecipientEditor()
        {
            InitializeComponent();
        }

        private void OnNameValidationError(object sender, ValidationErrorEventArgs e)
        {
            if(e.Action == ValidationErrorEventAction.Added) 
            {
                ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            }
            else
            {
                ((Control)sender).ClearValue(ToolTipProperty);
            }

        }

        private void OnIdValidationError(object sender, ValidationErrorEventArgs e)
        {

            if (e.Action == ValidationErrorEventAction.Added)
            {
                ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            }
            else
            {
                ((Control)sender).ClearValue(ToolTipProperty);
            }

        }
    }
}
