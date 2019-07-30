using BusinessLogic.Models;
using BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly IHackerNewsRepository _hackerNewsRepository;
        private ObjectCache _cache;
        private CacheItemPolicy _cacheItemPolicy;

        public HackerNewsService(IHackerNewsRepository hackerNewsRepository)
        {
            _hackerNewsRepository = hackerNewsRepository;
            _cache = MemoryCache.Default;
            _cacheItemPolicy = new CacheItemPolicy();
            _cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
        }

        public async Task<ICollection<HackerNewsStory>> GetNewStories(int page)
        {
            var stories = new List<HackerNewsStory>();
            if (ValidatePage(page))
            {
                var ids = await _hackerNewsRepository.GetNewStoryIds(page * 10, 10);
                foreach(var id in ids)
                {
                    var story = await GetStoryById(id);
                    stories.Add(story);
                }
            }
            return stories;
        }
        public HackerNewsStory GetStoryFromCache(int id)
        {
            return (HackerNewsStory)_cache.Get($"storyId:{id}");
        }

        public async Task<HackerNewsStory> GetStoryById(int id)
        {
            HackerNewsStory story = new HackerNewsStory();

            if (_cache.Contains($"storyId:{id}"))
            {
                story = GetStoryFromCache(id);
            }
            else
            {
                story = await _hackerNewsRepository.GetStoryById(id);
                _cache.Add($"storyId:{id}", story, _cacheItemPolicy);
            }
            return story;
        }

        public bool ValidatePage(int page)
        {
            return page >= 0 && page <= 49;
        }

        public ICollection<HackerNewsStory> Search(string search, int skip, int take)
        {
            return _cache.Where(x => x.Value.ToString().Contains(search))
                .Select(x => (HackerNewsStory)x.Value)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
    }
}
