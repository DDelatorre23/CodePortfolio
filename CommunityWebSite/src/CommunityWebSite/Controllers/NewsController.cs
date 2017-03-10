using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CommunityWebSite.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunityWebSite.Controllers {
    public class NewsController : Controller
    {
        List<NewsArticle> nullList = new List<NewsArticle>() {
                    new NewsArticle() {
                        Title = "",
                        DatePublished = DateTime.Today,
                        Article = ""
                    }
        };

        // GET: /<controller>/
        public IActionResult Index() {
            ViewData["Message"] = "Upcoming Events in Harrisburg";
            return View();
        }

        public IActionResult Today() {
            var newsList = NewsArchive.Articles.Where(n => n.DatePublished == DateTime.Today).ToList();
            if (newsList.Count > 0) {
                ViewData["Message"] = "Today's Local News";
                return View(newsList);
            } else {
                ViewData["Message"] = "No news stories today. Please come back later.";
                return View(nullList);
            }

        }

        public IActionResult Archive() {
            var archiveList = NewsArchive.Articles.Where(a => a.IsArchived == true).ToList();
            if (archiveList.Count > 0) {
                ViewData["Message"] = "News Archive";
                return View(archiveList);
            } else {
                ViewData["Message"] = "There are no stories in the archive.";
                return View(nullList);
            }

        }

    }
}
