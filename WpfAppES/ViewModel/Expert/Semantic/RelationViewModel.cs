using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppES.ViewModel.Expert
{
    public class RelationViewModel(string label)
    {
        public string Label { get; set; } = label;
    }
}
