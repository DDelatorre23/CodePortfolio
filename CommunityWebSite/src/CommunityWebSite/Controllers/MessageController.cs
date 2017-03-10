using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebSite.Models;
using CommunityWebSite.Repository;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunityWebSite.Controllers {
    public class MessageController : Controller {
        IMessage messageRepository;

        public MessageController(IMessage repo) {
            messageRepository = repo;
        }
        // GET: /<controller>/
        public ViewResult Index() {
            return View(messageRepository.GetAllMessages().ToList());
        }

        public ViewResult GetMessageByDateRange(DateTime start, DateTime end) {
            return View("Index", messageRepository.GetMessagesByDateRange(start, end));
        }

        public ViewResult GetMemberMessages(int memberID) {
            return View("Index", messageRepository.GetMessagesByMember(memberID));
        }

        public ViewResult GetMessagesByTopic (string topic) {
            return View("Index", messageRepository.GetMessagesByTopic(topic).ToList());
        }

    }
}
