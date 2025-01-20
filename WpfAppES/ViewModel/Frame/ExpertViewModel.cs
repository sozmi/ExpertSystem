using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfAppES.ViewModel.BaseObjects;
using System.Threading.Tasks;
using ClassLibraryES.frame_es;

namespace WpfAppES.ViewModel.Frame
{
    public class ExpertViewModel : BaseViewModel
    {
        public SlotViewModel SlotViewModel { get; }
        public FrameViewModel FrameViewModel { get; }

        public ExpertViewModel()
        {
            SlotViewModel = new SlotViewModel();
            FrameViewModel = new FrameViewModel();

            // Инициализация общих данных, если требуется
            // Например, связь слотов между ViewModel
            FrameViewModel.AllSlots = SlotViewModel.Slots;
        }
    }
}
