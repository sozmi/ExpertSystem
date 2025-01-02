using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppES.ViewModel.BaseObjects;
using System.Collections.ObjectModel;
using ClassLibraryES.frame_es;

namespace WpfAppES.ViewModel.Frame
{
    public class EditSlotViewModel : BaseViewModel
    {
        public Slot Slot { get; }

        public ObservableCollection<string> Values { get; set; }

        public EditSlotViewModel(Slot slot)
        {
            Slot = slot;
            Values = new ObservableCollection<string> { slot.Value };
        }

        public void SaveChanges()
        {
            if (Values.Count > 0)
            {
                Slot.Value = Values[0];
                // TODO: Добавить логику сохранения дополнительных значений, если потребуется
            }
        }
    }
}
