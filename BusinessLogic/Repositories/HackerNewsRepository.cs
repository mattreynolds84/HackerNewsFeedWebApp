using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using BusinessLogic.Models;
using Newtonsoft.Json;

namespace BusinessLogic.Repositories
{
    public class HackerNewsRepository : IHackerNewsRepository
    {
        private HttpClient _httpClient;


        public HackerNewsRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ICollection<int>> GetNewStoryIds(int skip, int take)
        {
            List<int> ids = new List<int>();
            var response = await _httpClient.GetAsync(HackerNewsUris.NewStories);

            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                ids = JsonConvert.DeserializeObject<List<int>>(message).Skip(skip).Take(take).ToList();
            }

            return ids;
        }

        public async Task<HackerNewsStory> GetStoryById(int id)
        {
            HackerNewsStory story = new HackerNewsStory();
            var response = await _httpClient.GetAsync(HackerNewsUris.Story + id.ToString() + ".json");

            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                story = JsonConvert.DeserializeObject<HackerNewsStory>(message);
            }

            return story;
        }
    }
}
