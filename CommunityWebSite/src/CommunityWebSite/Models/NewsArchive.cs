using System;
using System.Collections.Generic;


namespace CommunityWebSite.Models {
    public class NewsArchive
    {
       private static List<NewsArticle> articles = new List<NewsArticle>() {
           new NewsArticle() {
               Title = "Upcoming Events at the Gazebo",
               DatePublished = new DateTime(2017, 1, 23),
               Article = "List of events goes here",
               IsArchived = false },
           new NewsArticle() {
               Title = "December Events",
               DatePublished = new DateTime(2016, 12, 1),
               Article = "List of events goes here",
               IsArchived = true },
           new NewsArticle() {
               Title = "November Events",
               DatePublished = new DateTime(2016, 11, 1),
               Article = "List of events goes here",
               IsArchived = true }
           };

        public static IEnumerable<NewsArticle> Articles {
            get {
                return articles;
            }
        }
    }
}
