using System.Windows;


namespace WpfAppES.Common
{
    /// <summary>
    /// Логика взаимодействия для MessageBox.xaml
    /// </summary>
    public partial class MessageBox : Window
    {
        public MessageBox(string question, string title)
        {
            InitializeComponent();
            txtQuestion.Text = question;
            Title = title;
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        public static void Show(string question, string title)
        {
            new MessageBox(question, title).Show();
        }
    }
}
