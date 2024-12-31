using ClassLibraryES.semantic_es;
using System.Collections.ObjectModel;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.UseCases
{
    public class DataGridFactsViewModel : BaseViewModel
    {
        public DataGridFactsViewModel(List<Fact> facts)
        {
            foreach (var fact in facts)
                Facts.Add(new(fact));
            addCommand = new(Add);
            removeCommand = new(Remove);
        }
        public ObservableCollection<RowFactsViewModel> Facts { get => _facts; set => SetProperty(ref _facts, value); }
        private ObservableCollection<RowFactsViewModel> _facts = [];

        public RowFactsViewModel? SelectedFact { get => _selectedFact; set => SetProperty(ref _selectedFact, value); }
        private RowFactsViewModel? _selectedFact;

        public RelayAction AddCommand => addCommand;
        readonly RelayAction addCommand;
        private void Add()
        {
            Fact fact = new();
            Facts.Add(new(fact));
        }

        public RelayAction RemoveCommand => removeCommand;
        readonly RelayAction removeCommand;

        private void Remove()
        {
            if (SelectedFact == null)
            {
                Common.MessageBox.Show("Необходимо выделить факт", "Ошибка");
                return;
            }

            var index = Facts.IndexOf(SelectedFact);
            SelectedFact = null;
            Facts.RemoveAt(index);
        }
    }
}
