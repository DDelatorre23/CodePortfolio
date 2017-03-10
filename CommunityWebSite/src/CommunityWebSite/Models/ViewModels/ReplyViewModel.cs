
namespace CommunityWebSite.Models.ViewModels
{
    public class ReplyViewModel
    {
        public int MessageID { get; set; }
        public string Subject { get; set; }
        public Reply MessageReply { get; set; }
    }
}
