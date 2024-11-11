using System.Windows;
using System.Windows.Controls;
using WpfAppES.ViewModel;

namespace WpfAppES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string? lastPage, lastInterface;
      
        public MainWindow()
        {
            InitializeComponent();
            expert.Checked += Interface_Checked;
            user.Checked += Interface_Checked;
            dbFrame.Checked += KnowledgeDB_Checked;
            dbLogical.Checked += KnowledgeDB_Checked;
            dbProduct.Checked += KnowledgeDB_Checked;
            dbSemantic.Checked += KnowledgeDB_Checked;

            expert.IsChecked = true;
            dbSemantic.IsChecked = true;
        }
        
        private void KnowledgeDB_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            lastPage = rb.Tag.ToString();
            if (frame == null || lastInterface == null)
                return;
            frame.Navigate(new Uri($"/{lastInterface}/{lastPage}", UriKind.Relative));
        }

        private void Interface_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            lastInterface = rb.Tag.ToString();
            if (frame == null || lastPage == null)
                return;
            frame.Navigate(new Uri($"/{lastInterface}/{lastPage}", UriKind.Relative));
        }
    }
}