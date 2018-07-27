using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace www.Models
{
    interface ITipsViewModel
    {
        TipsTableViewModel GetTipsViewModel();
        JumboNavViewModel GetJumboNavViewModel();
        string GetPageTitle();
        string GetViewName();
        string GetPageMessage();
    }
}
