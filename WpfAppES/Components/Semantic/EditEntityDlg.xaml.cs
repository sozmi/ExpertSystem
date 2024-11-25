using System.Windows;
using WpfAppES.ViewModel.Semantic;

namespace WpfAppES.Components.Semantic
{
    /// <summary>
    /// Логика взаимодействия для EditEntity.xaml
    /// </summary>
    public partial class EditEntityDlg : Window
    {
        public EditEntityDlg(EntityViewModel entityView)
        {
            InitializeComponent();
            DataContext = entityView;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
