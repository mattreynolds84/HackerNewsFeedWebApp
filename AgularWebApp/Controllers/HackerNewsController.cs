using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Models;
using BusinessLogic.Services;

namespace AgularWebApp.Controllers
{
    [Route("api/[controller]")]
    public class HackerNewsController : Controller
    {
        private readonly IHackerNewsService _hackerNewsService;
        public HackerNewsController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        [HttpGet("[action]")]
        public async Task<ICollection<HackerNewsStory>> NewStories(int page = 0)
        {
            return await _hackerNewsService.GetNewStories(page);
        }
    }
}
