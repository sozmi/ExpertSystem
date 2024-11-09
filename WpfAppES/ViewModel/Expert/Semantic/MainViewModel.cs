using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfAppES.ViewModel.Expert.Semantic
{
    class MainViewModel
    {
        public ObservableCollection<RelationViewModel> Relations { get; set; } = [];

        public ICommand AddRowCommand { get; set; }

        public MainViewModel()
        {
            AddRowCommand = new RelayCommand(AddRow);
        }

        private void AddRow() => Relations.Add(new RelationViewModel("Пустая строка"));
    }
}
