using ClassLibraryES.frame_es;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryES.frame_es;
using System.Windows.Input;
using WpfAppES.Components.Frame.Slot;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Frame
{
        public class SlotViewModel : BaseViewModel
    {
            public ObservableCollection<Slot> Slots { get; set; }

            public ICommand AddSlotCommand { get; }
            public ICommand RemoveSlotCommand { get; }
            public ICommand EditSlotCommand { get; }

            public SlotViewModel()
            {
                Slots = new ObservableCollection<Slot>();

                AddSlotCommand = new RelayCommand(AddSlot);
                RemoveSlotCommand = new RelayCommand(RemoveSlot, CanRemoveSlot);
                EditSlotCommand = new RelayCommand(EditSlot, CanEditSlot);
            }

            private void AddSlot(object? obj)
            {// TODO: реализовать добавление нового слота
                throw new NotImplementedException();
            }


            private void RemoveSlot(object parameter)
            {
                if (parameter is Slot slot)
                {
                    Slots.Remove(slot);
                }
            }

            private bool CanRemoveSlot(object parameter)
            {
                return parameter is Slot;
            }

            private void EditSlot(object parameter)
            {
                if (parameter is Slot slot)
                {
                    var editWindow = new EditSlotWindow
                    {
                        DataContext = new EditSlotViewModel(slot)
                    };

                    editWindow.ShowDialog();

                    // TODO: обработать сохранение изменений
                }
            }

            private bool CanEditSlot(object parameter)
            {
                return parameter is Slot;
            }
        }
 }

