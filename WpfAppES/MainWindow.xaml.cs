using ClassLibraryES.Managers;
using HandyControl.Tools;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfAppES
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        string? lastPage, lastInterface;
        /// <summary>
        /// Название приложения
        /// </summary>
        readonly string defaultTitle;

        public MainWindow()
        {
            InitializeComponent();
            expert.Checked += Interface_Checked;
            user.Checked += Interface_Checked;
            dbFrame.Checked += KnowledgeDB_Checked;
            dbLogical.Checked += KnowledgeDB_Checked;
            dbProduct.Checked += KnowledgeDB_Checked;
            dbSemantic.Checked += KnowledgeDB_Checked;

            //выбор начальной страницы

            expert.IsChecked = true;
            dbSemantic.IsChecked = true;
            //frame.Navigate(new Uri($"StartPage.xaml", UriKind.Relative));
            defaultTitle = Title;

            ConfigHelper.Instance.SetLang("ru");
        }

        /// <summary>
        /// Событие, происходит при смене базы знаний.
        /// Переключаем страницу на соответствующую.
        /// Адрес страницы берется из свойства Tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KnowledgeDB_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            lastPage = rb.Tag.ToString();
            if (frame == null || lastInterface == null)
                return;
            frame.Navigate(new Uri($"/View/{lastInterface}/{lastPage}", UriKind.Relative));
        }

        /// <summary>
        /// Событие, происходит при смене интерфейса.
        /// Переключаем страницу на соответствующую.
        /// Адрес страницы берется из свойства Tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Interface_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            lastInterface = rb.Tag.ToString();
            if (frame == null || lastPage == null)
                return;
            frame.Navigate(new Uri($"/View/{lastInterface}/{lastPage}", UriKind.Relative));
        }

        /// <summary>
        /// Обработка создания новой ЭС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Common.Dialog dialog = new("Введите название экспертной системы", "Создание ЭС");
            if (dialog.ShowDialog() != true)
                return;//отменили создание новой ЭС
            try
            {
                string nameES = dialog.ResponseText;
                KnowledgeBaseManager.Get().Create(nameES);
                Title = defaultTitle+ " " + nameES;
            }
            catch (FileLoadException ex)
            {
                new Common.MessageBox(ex.Message, "Ошибка").Show();
            }
            
        }

        /// <summary>
        /// Обработка открытия существующей ЭС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //TODO: реализовать открытие э.с. из файла и обработку ошибок
            Microsoft.Win32.OpenFileDialog dlg = new()
            {
                InitialDirectory = KnowledgeBaseManager.Get().PATH_TO_DIR,
                DefaultExt = ".es",
                Filter = "Экспертные системы  (*.es)|*.es;*.*"
            };
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                KnowledgeBaseManager.Get().Load(filename);
            }
        }

        /// <summary>
        /// Обработка сохранения ЭС с тем же названием
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
           //TODO: реализовать сохранение и обработку ошибок
        }

        /// <summary>
        /// Обработка сохранения ЭС с тем же названием
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //TODO: реализовать закрытие э.с. и обработку ошибок
            //TODO: при закрытии ЭС при наличии изменений нужно спросить нужно ли сохраниться 
        }

        /// <summary>
        /// Обработка сохранения в файле, выбранном пользователем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //TODO: реализовать сохранение как и обработку ошибок
            Microsoft.Win32.OpenFileDialog dlg = new()
            {
                DefaultExt = ".es",
                Filter = "Экспертные системы  (*.es)|*.es"
            };
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;

            }
        }
    }
}