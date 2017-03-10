using System;

namespace CommunityWebSite.Models {
    public class NewsArticle
    {
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
        public string Article { get; set; }
        public bool IsArchived { get; set; }
    }
}
