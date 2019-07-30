using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface IHackerNewsRepository
    {
        Task<HackerNewsStory> GetStoryById(int id);
        Task<ICollection<int>> GetNewStoryIds(int skip, int take);
    }
}
