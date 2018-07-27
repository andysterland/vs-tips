using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using www.Models;

namespace www.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            rest_api.Models.Tip[] tips = await TipViewManager.GetRandomTips(10);
            IndexViewModel viewModel = new IndexViewModel(tips);

            return View(viewModel);
        }

        [HttpGet("search/")]
        public async Task<IActionResult> Search()
        {
            return View(new SearchViewModel());
        }

        [HttpPost("search/")]
        public async Task<IActionResult> Search(string term)
        {
            rest_api.Models.Tip[] tips = await TipViewManager.GetSearchTips(term);
            SearchViewModel viewModel = new SearchViewModel(tips, term);
            return View(viewModel);          
        }

        [HttpGet("tag/{tag}")]
        public async Task<IActionResult> Tag(string tag)
        {
            rest_api.Models.Tip[] tips = await TipViewManager.GetTipsByTag(tag);
            TagViewModel viewModel = new TagViewModel(tips, tag);

            return View(viewModel);
        }

        [HttpGet("tip/{id}")]
        public async Task<IActionResult> Tip(string id)
        {
            rest_api.Models.Tip tip = await TipViewManager.GetTipById(id);
            TipViewModel viewModel = new TipViewModel(tip);

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Privacy()
        {
            return Redirect("https://privacy.microsoft.com/privacystatement");
        }
    }
}
