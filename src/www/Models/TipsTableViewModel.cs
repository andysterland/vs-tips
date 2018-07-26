using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace www.Models
{
    public class TipsTableViewModel
    {
        public rest_api.Models.Tip[] Tips;

        public TipsTableViewModel(rest_api.Models.Tip[] tips)
        {
            this.Tips = tips;
        }
    }
}
