using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
using System.Windows;
using WpfAppES.ViewModel.Semantic.Entities.Item;

namespace WpfAppES.Components.Semantic
{
    /// <summary>
    /// Логика взаимодействия для EditEntity.xaml
    /// </summary>
    public partial class EditEntityDlg : Window
    {
        public EditEntityDlg(Guid id)
        {
            InitializeComponent();
            var db = KnowledgeBaseManager.GetBase<SemanticDB>();
            if (db == null) return; 
            DataContext = new EntityViewModel(db.GetEntity(id));
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (((EntityViewModel)DataContext).SaveChanges()) 
                DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
