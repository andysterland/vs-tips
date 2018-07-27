using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using rest_api.Models;

namespace rest_api.Controllers
{
    [ApiController]
    [EnableCors("CorsAcceptAll")]
    public class TipsController : ControllerBase
    {
        // GET api/tips
        [HttpGet("api/tips/")]
        public ActionResult<List<Tip>> Get()
        {
            return Global.Tips.GetAllTips();
        }

        // GET api/tips/foo
        [HttpGet("api/tips/{id}")]
        public ActionResult<Tip> Get(string id)
        {
            return Global.Tips.GetTipById(id);
        }

        // GET api/tips/tag/tag
        [HttpGet("api/tips/tag/{tag}")]
        public ActionResult<List<Tip>> GetByTags(string tag)
        {
            return Global.Tips.GetTipsByTag(tag);
        }

        [HttpGet("api/tips/random/{count}")]
        public ActionResult<List<Tip>> GetRandom(int count)
        {
            return Global.Tips.GetRandomTips(count);
        }
    }
}
