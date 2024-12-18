using ClassLibraryES.Managers;
using HandyControl.Controls;
using HandyControl.Tools;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfAppES.ViewModel;

namespace WpfAppES;

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

    // Модель представления для связи данных с интерфейсом
    private readonly MainViewModel _viewModel = new();
    public MainWindow()
    {
        InitializeComponent();

        // Устанавливаем модель представления как DataContext для привязки данных
        DataContext = _viewModel;

        expert.Checked += Interface_Checked;
        user.Checked += Interface_Checked;
        dbFrame.Checked += KnowledgeDB_Checked;
        dbLogical.Checked += KnowledgeDB_Checked;
        dbProduct.Checked += KnowledgeDB_Checked;
        dbSemantic.Checked += KnowledgeDB_Checked;

        // Устанавливаем начальную страницу
        frame.Navigate(new Uri($"Pages/StartPage.xaml", UriKind.Relative));
        defaultTitle = Title;

        ConfigHelper.Instance.SetLang("ru");
    }

    /// <summary>
    /// Обработчик изменения базы знаний. 
    /// Переключает страницу, основываясь на значении свойства Tag.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void KnowledgeDB_Checked(object sender, RoutedEventArgs e)
    {
        if (sender is RadioButton rb)
        {
            lastPage = rb.Tag.ToString();
            UpdatePageNavigation();
        }
    }

    /// <summary>
    /// Обработчик изменения интерфейса. 
    /// Переключает страницу, основываясь на значении свойства Tag.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Interface_Checked(object sender, RoutedEventArgs e)
    {
        if (sender is RadioButton rb)
        {
            lastInterface = rb.Tag.ToString();
            UpdatePageNavigation();
        }
    }

    /// <summary>
    /// Обновляет навигацию на основе текущих значений lastInterface и lastPage.
    /// </summary>
    private void UpdatePageNavigation()
    {
        if (frame != null && lastInterface != null && lastPage != null)
        {
            frame.Navigate(new Uri($"/Pages/{lastInterface}/{lastPage}", UriKind.Relative));
        }
    }
    /// <summary>
    /// Создание новой экспертной системы.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        HandleUnsavedChanges();

        Common.Dialog dialog = new("Введите название экспертной системы", "Создание ЭС");
        if (dialog.ShowDialog() == true)
        {
            try
            {
                string nameES = dialog.ResponseText;
                KnowledgeBaseManager.Get().Create(nameES);
                UpdateUIAfterSuccess(nameES);
            }
            catch (Exception ex)
            {
                new Common.MessageBox(ex.Message, "Ошибка").Show();
            }
        }
    }

    /// <summary>
    /// Открытие существующей экспертной системы.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        HandleUnsavedChanges();

        Microsoft.Win32.OpenFileDialog dlg = new()
        {
            InitialDirectory = KnowledgeBaseManager.Get().PATH_TO_DIR,
            DefaultExt = ".es",
            Filter = "Экспертные системы (*.es)|*.es"
        };

        if (dlg.ShowDialog() == true)
        {
            try
            {
                string fileName = dlg.FileName;
                KnowledgeBaseManager.Get().Load(fileName);
                UpdateUIAfterSuccess(Path.GetFileNameWithoutExtension(fileName));
            }
            catch (Exception ex)
            {
                new Common.MessageBox(ex.Message, "Ошибка").Show();
            }
        }
    }

    /// <summary>
    /// Сохранение текущей экспертной системы.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        try
        {
            KnowledgeBaseManager.Get().Save();
        }
        catch (Exception ex)
        {
            new Common.MessageBox(ex.Message, "Ошибка").Show();
        }
    }


    /// <summary>
    /// Сохранение текущей ЭС в выбранный пользователем файл.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        Microsoft.Win32.SaveFileDialog dlg = new()
        {
            DefaultExt = ".es",
            Filter = "Экспертные системы (*.es)|*.es"
        };

        if (dlg.ShowDialog() == true)
        {
            try
            {
                KnowledgeBaseManager.Get().PATH_TO_FILE = dlg.FileName;
                KnowledgeBaseManager.Get().Save();
            }
            catch (Exception ex)
            {
                new Common.MessageBox(ex.Message, "Ошибка").Show();
            }
        }
    }

    /// <summary>
    /// Закрытие текущей экспертной системы.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        HandleUnsavedChanges();

        KnowledgeBaseManager.Get().Close();
        ResetUIToDefault();

        // Сброс выбора вкладок
        expert.IsChecked = false;
        user.IsChecked = false;
        dbLogical.IsChecked = false;
        dbProduct.IsChecked = false;
        dbSemantic.IsChecked = false;
        dbFrame.IsChecked = false;

    }

    /// <summary>
    /// Проверка на наличие несохраненных изменений.
    /// Если они есть, предлагается сохранить.
    /// </summary>
    private void HandleUnsavedChanges()
    {
        if (KnowledgeBaseManager.Get().ChangesMade)
        {
            Common.MessageBox saveDialog = new("Сохранить изменения?", "Подтверждение");
            if (saveDialog.ShowDialog() == true)
            {
                try
                {
                    KnowledgeBaseManager.Get().Save();
                }
                catch (Exception ex)
                {
                    new Common.MessageBox(ex.Message, "Ошибка").Show();
                }
            }
        }
    }
    /// <summary>
    /// Обновление интерфейса после успешной загрузки или создания ЭС.
    /// </summary>
    /// <param name="nameES"></param>
    private void UpdateUIAfterSuccess(string nameES)
    {
        Title = $"{defaultTitle} {nameES}";
        _viewModel.SaveEnabled = true;
        _viewModel.InterfaceMenuVisibility = Visibility.Visible;
        _viewModel.KnowledgeMenuVisibility = Visibility.Visible;
        UpdatePageNavigation();
    }
    /// <summary>
    /// Сброс интерфейса до начального состояния. 
    /// </summary>
    private void ResetUIToDefault()
    {
        Title = defaultTitle;
        _viewModel.SaveEnabled = false;
        _viewModel.InterfaceMenuVisibility = Visibility.Collapsed;
        _viewModel.KnowledgeMenuVisibility = Visibility.Collapsed;
        frame.Navigate(new Uri($"Pages/StartPage.xaml", UriKind.Relative));

        // Сброс выбора вкладок
        expert.IsChecked = false;
        user.IsChecked = false;
        dbLogical.IsChecked = false;
        dbProduct.IsChecked = false;
        dbSemantic.IsChecked = false;
        dbFrame.IsChecked = false;

    }

}