using ClassLibraryES.frame_es;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppES.ViewModel.BaseObjects;
using ClassLibraryES.frame_es;

namespace WpfAppES.ViewModel.Frame
{
    public class EditFrameViewModel : BaseViewModel
    {
        public FrameDB Frame { get; }

        public ObservableCollection<Slot> AllSlots { get; }
        public ObservableCollection<FrameDB> ParentFrames { get; }

        public EditFrameViewModel(FrameDB frame, ObservableCollection<Slot> allSlots, ObservableCollection<FrameDB> parentFrames)
        {
            Frame = frame;
            AllSlots = allSlots;
            ParentFrames = parentFrames;
        }

        public void SaveChanges()
        {
            // TODO: Реализовать сохранение изменений для фрейма
        }
    }
}
