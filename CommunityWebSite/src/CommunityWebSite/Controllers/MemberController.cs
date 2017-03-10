using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebSite.Models;
using CommunityWebSite.Repository;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunityWebSite.Controllers
{
    public class MemberController : Controller
    {
        IMember repo;

        public MemberController (IMember repository) {
            repo = repository;
        }
        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(repo.GetAllMembers().ToList());
        }
       
    }
}
