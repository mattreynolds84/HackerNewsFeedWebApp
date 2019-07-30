using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IHackerNewsService
    {
        Task<ICollection<HackerNewsStory>> GetNewStories(int page);
    }
}
