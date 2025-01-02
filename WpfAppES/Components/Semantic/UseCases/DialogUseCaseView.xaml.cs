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
using WpfAppES.ViewModel.Semantic.Entities.Item;
using WpfAppES.ViewModel.Semantic.UseCases;

namespace WpfAppES.Components.Semantic.UseCases;

/// <summary>
/// Логика взаимодействия для DialogUseCaseView.xaml
/// </summary>
public partial class DialogUseCaseView : Window
{
    public DialogUseCaseView(Guid id)
    {
        InitializeComponent();
        DataContext = new UseCaseViewModel(id);
    }

    private void ButtonSave_Click(object sender, RoutedEventArgs e)
    {
        if (((UseCaseViewModel)DataContext).SaveChanges())
            DialogResult = true;
    }

    private void ButtonCancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
