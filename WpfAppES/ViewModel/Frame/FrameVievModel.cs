using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppES.Components.Frame;
using ClassLibraryES.frame_es;
using System.Windows.Input;
using WpfAppES.Components.Frame.Frame;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Frame
{
    public class FrameViewModel : BaseViewModel
    {
        public ObservableCollection<FrameDB> Frames { get; set; }
        public ObservableCollection<Slot> AllSlots { get; set; }

        public ICommand AddFrameCommand { get; }
        public ICommand RemoveFrameCommand { get; }
        public ICommand EditFrameCommand { get; }

        public FrameViewModel()
        {
            Frames = new ObservableCollection<FrameDB>();
            AllSlots = new ObservableCollection<Slot>();

            AddFrameCommand = new RelayCommand(AddFrame);
            RemoveFrameCommand = new RelayCommand(RemoveFrame, CanRemoveFrame);
            EditFrameCommand = new RelayCommand(EditFrame, CanEditFrame);
        }

        private void AddFrame(object? obj)
        {// TODO: реализовать добавление нового фрейма
            throw new NotImplementedException();
        }


        private void RemoveFrame(object parameter)
        {
            if (parameter is FrameDB frame)
            {
                Frames.Remove(frame);
            }
        }

        private bool CanRemoveFrame(object parameter)
        {
            return parameter is FrameDB;
        }

        private void EditFrame(object parameter)
        {
            if (parameter is FrameDB frame)
            {
                var editWindow = new EditFrameWindow
                {
                    DataContext = new EditFrameViewModel(frame, AllSlots, Frames)
                };

                editWindow.ShowDialog();

                // TODO: обработать сохранение изменений
            }
        }

        private bool CanEditFrame(object parameter)
        {
            return parameter is FrameDB;
        }
    }
}
