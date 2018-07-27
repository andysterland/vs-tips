using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace www.Models
{
    public class JumboNavViewModel
    {
        public string CurrentView { private set; get; }

        public JumboNavViewModel(string currentView)
        {
            CurrentView = currentView;
        }
    }
}
