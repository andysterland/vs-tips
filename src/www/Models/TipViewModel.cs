using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace www.Models
{
    public class TipViewModel
    {
        public rest_api.Models.Tip Tip { get; private set; }

        public TipViewModel(rest_api.Models.Tip tip)
        {
            Tip = tip;
        }

        public string GetTagString()
        {
            return string.Join(",", Tip.Tags);
        }
    }
}
