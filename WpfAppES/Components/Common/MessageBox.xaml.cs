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
    }
}
