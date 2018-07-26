using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace www.Models
{
    public class SearchViewModel : ITipsViewModel
    {

        private TipsTableViewModel _tipsViewModel;
        private string _pageTitle;
        private string _pageMessage;
        private string _viewName;
        private string _searchTerm;

        public SearchViewModel()
        {
            _pageTitle = "Search Tips";
        }

        public SearchViewModel(rest_api.Models.Tip[] tips, string searchTerm)
        {
            _tipsViewModel = new TipsTableViewModel(tips);
            _viewName = "search";
            _searchTerm = searchTerm;
            _pageTitle = $"Search results for {_searchTerm}";


            if (_tipsViewModel != null || _tipsViewModel.Tips != null || _tipsViewModel.Tips.Length == 0)
            {
                _pageMessage = $"Sorry, we didn't find any matches for {_searchTerm}.";
            }
            else
            {
                string pluralize = (_tipsViewModel.Tips.Length == 1) ? "match" : "matches";
                _pageMessage = $"Found {_tipsViewModel.Tips.Length} {pluralize} for {_searchTerm}.";
            }
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

        public string GetSearchTerm()
        {
            return _searchTerm;
        }

        public string GetPageMessage()
        {
            return _pageMessage;
        }

        public string GetPlaceholderText()
        {
            return (string.IsNullOrWhiteSpace(_searchTerm)) ? "Search" : _searchTerm;
        }
    }
}
