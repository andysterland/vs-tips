using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace www.Models
{
    public class IndexViewModel : ITipsViewModel
    {
        private TipsTableViewModel _tipsViewModel;
        private string _pageTitle;
        private string _viewName;

        public IndexViewModel(rest_api.Models.Tip[] tips)
        {
            _tipsViewModel = new TipsTableViewModel(tips);
            _pageTitle = "Random Tips";
            _viewName = "index";
        }

        public string GetPageTitle()
        {
            return _pageTitle;
        }

        public TipsTableViewModel GetTipsViewModel()
        {
            return _tipsViewModel;
        }

        public string GetViewName()
        {
            return _viewName;
        }

        public string GetPageMessage()
        {
            return string.Empty;
        }
    }
}
