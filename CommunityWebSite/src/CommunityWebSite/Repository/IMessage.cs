using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebSite.Models;
namespace CommunityWebSite.Repository
{
    public interface IMessage
    {
        IEnumerable<Message> GetAllMessages();
        List<Message> GetMessagesByMember(int memberID);
        List<Message> GetMessagesByDateRange(DateTime start, DateTime end);
        List<Message> GetMessagesByTopic(string topic);
        int Update(Message message);
    }
}
