using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    public class HackerNewsStory
    {
        public string By { get; set; }
        public int Descendants { get; set; }
        public int Id { get; set; }
        public ICollection<int> Kids { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }
}
