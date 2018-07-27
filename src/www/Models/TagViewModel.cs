using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace www.Models
{
    public class TagViewModel : ITipsViewModel
    {

        private TipsTableViewModel _tipsViewModel;
        private JumboNavViewModel _jumboNavViewModel;
        private string _pageTitle;
        private string _viewName = "tag";
        private string _tag;

        public TagViewModel(rest_api.Models.Tip[] tips, string tag)
        {
            _tipsViewModel = new TipsTableViewModel(tips);
            _viewName = $"tag/{tag}";
            _jumboNavViewModel = new JumboNavViewModel(_viewName);
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string tagTitle = textInfo.ToTitleCase(tag); 
            _pageTitle = $"{tagTitle} Tips";
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

        public string GetTag()
        {
            return _tag;
        }

        public string GetPageMessage()
        {
            return string.Empty;
        }

        public JumboNavViewModel GetJumboNavViewModel()
        {
            return _jumboNavViewModel;
        }
    }
}
