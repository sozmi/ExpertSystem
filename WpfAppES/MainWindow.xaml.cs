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
        private bool hasChanges = false; // Локальный флаг изменений
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

            frame.Navigate(new Uri($"View/StartPage.xaml", UriKind.Relative));
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
        /// Переход на стартовую страницу приложения
        /// </summary>
        private void NavigateToStartPage()
        {
            if (frame != null)
            {
                frame.Navigate(new Uri("/View/StartPage.xaml", UriKind.Relative));
            }
            Title = defaultTitle; // Сброс заголовка окна
        }

        /// <summary>
        /// Обработка создания новой ЭС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!CheckForUnsavedChanges()) return;

            // Закрываем текущую ЭС, сбрасывая состояние
            ResetApplicationState();

            try
            {
                Common.Dialog dialog = new("Введите название экспертной системы", "Создание ЭС");
                if (dialog.ShowDialog() == true)
                {
                    string nameES = dialog.ResponseText;
                    KnowledgeBaseManager.Get().Create(nameES);

                    Title = $"{defaultTitle} {nameES}";
                    ToggleMainUIVisibility(true);
                    ResetChanges();
                }
            }
            catch (Exception ex)
            {
                new Common.MessageBox($"Ошибка при создании: {ex.Message}", "Ошибка").Show();
            }
        }

        /// <summary>
        /// Обработка открытия существующей ЭС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!CheckForUnsavedChanges()) return;

            Microsoft.Win32.OpenFileDialog dlg = new()
            {
                InitialDirectory = KnowledgeBaseManager.Get().PATH_TO_DIR,
                DefaultExt = ".es",
                Filter = "Экспертные системы (*.es)|*.es"
            };

            bool? resultDialog = dlg.ShowDialog();
            if (resultDialog == true)
            {
                string filePath = dlg.FileName;

                try
                {
                    KnowledgeBaseManager.Get().Load(filePath);
                    Title = $"{defaultTitle} {Path.GetFileNameWithoutExtension(filePath)}";
                    ToggleMainUIVisibility(true);
                    ResetChanges();
                }
                catch (Exception ex)
                {
                    new Common.MessageBox($"Ошибка при открытии: {ex.Message}", "Ошибка").Show();
                }
            }
        }


        /// <summary>
        /// Обработка сохранения ЭС с тем же названием
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                KnowledgeBaseManager.Get().Save();
                ResetChanges();
                new Common.MessageBox("Экспертная система успешно сохранена.", "Сохранение").Show();
            }
            catch (Exception ex)
            {
                new Common.MessageBox($"Ошибка при сохранении: {ex.Message}", "Ошибка").Show();
            }
        }

        /// <summary>
        /// Обработка сохранения ЭС с тем же названием
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
                if (!CheckForUnsavedChanges()) return;

                NavigateToStartPage(); // Переход на стартовую страницу
                ToggleMainUIVisibility(false); // Отключаем элементы
                ResetMenuSelections(); // Сбрасываем выборы в меню
                ResetApplicationState();
        }


        /// <summary>
        /// Обработка сохранения в файле, выбранном пользователем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Открываем диалоговое окно для выбора нового файла
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog()
            {
                DefaultExt = ".es",
                Filter = "Экспертные системы (*.es)|*.es"
            };

            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string newFilePath = dlg.FileName;

                try
                {
                    // Изменяем путь для сохранения
                    KnowledgeBaseManager.Get().PATH_TO_FILE = newFilePath;

                    // Сохраняем данные в новый файл
                    KnowledgeBaseManager.Get().Save();

                    // Сброс изменений после сохранения
                    ResetChanges();

                    // Показать сообщение об успешном сохранении
                    new Common.MessageBox("Экспертная система успешно сохранена в новый файл.", "Сохранение").Show();
                }
                catch (Exception ex)
                {
                    new Common.MessageBox($"Ошибка при сохранении: {ex.Message}", "Ошибка").Show();
                }
            }
        }


        /// <summary>
        /// Сброс состояния приложения для "закрытия" текущей ЭС
        /// </summary>
        private void ResetApplicationState()
        {
            // Скрываем элементы интерфейса
            ToggleMainUIVisibility(false);

            // Сбрасываем заголовок окна
            Title = defaultTitle;

            // Очищаем внутренние данные
            hasChanges = false;
            lastPage = null;
            lastInterface = null;


        }

        /// <summary>
        /// Отмечаем изменения в ЭС
        /// </summary>
        private void MarkChanges()
        {
            hasChanges = true;
            menuSave.IsEnabled = true; // Включаем кнопку сохранения
        }

        /// <summary>
        /// Сброс изменений после сохранения
        /// </summary>
        private void ResetChanges()
        {
            hasChanges = false;
            menuSave.IsEnabled = false;
        }


        /// <summary>
        /// Управляет видимостью элементов меню, зависящих от состояния ЭС
        /// </summary>
        /// <param name="isVisible">Если true, элементы включаются; если false, выключаются</param>
        private void ToggleMainUIVisibility(bool isVisible)
        {
            // Управление пунктами меню
            menuSave.IsEnabled = isVisible;
            menuSaveAs.IsEnabled = isVisible;
            menuClose.IsEnabled = isVisible;

            // Управление вкладками
            menuInterface.IsEnabled = isVisible;
            menuKnowledge.IsEnabled = isVisible;
        }


        /// <summary>
        /// Сбрасывает выборы в меню "Интерфейс" и "База знаний" (снимает все выделения).
        /// </summary>
        private void ResetMenuSelections()
        {
            // Сбрасываем выбор в меню "Интерфейс"
            if (expert != null && user != null)
            {
                expert.IsChecked = false;
                user.IsChecked = false;
            }

            // Сбрасываем выбор в меню "База знаний"
            if (dbLogical != null && dbProduct != null && dbSemantic != null && dbFrame != null)
            {
                dbLogical.IsChecked = false;
                dbProduct.IsChecked = false;
                dbSemantic.IsChecked = false;
                dbFrame.IsChecked = false;
            }
        }

        private bool CheckForUnsavedChanges()
        {
            if (!hasChanges) return true;

            var result = MessageBox.Show("Сохранить изменения перед продолжением?",
                                         "Сохранение", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    KnowledgeBaseManager.Get().Save();
                    ResetChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    new Common.MessageBox($"Ошибка при сохранении: {ex.Message}", "Ошибка").Show();
                    return false;
                }
            }

            return result == MessageBoxResult.No;
        }

    }
}