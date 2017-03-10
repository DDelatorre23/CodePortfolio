using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebSite.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Member Sender { get; set; }
        public string Topic { get; set; }

        private List<Reply> replies = new List<Reply>();
        public List<Reply> MessageReplies { get { return replies; } }

    }
}
