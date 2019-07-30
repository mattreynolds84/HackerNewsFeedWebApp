using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Constants
{
    public static class HackerNewsUris
    {
        public static string BaseUri
        {
            get
            {
                return "https://hacker-news.firebaseio.com/v0/";
            }
        }

        public static string NewStories
        {
            get
            {
                return BaseUri + "newstories.json";
            }
        }

        public static string Story
        {
            get
            {
                return BaseUri + "item/";
            }
        }
    }
}
