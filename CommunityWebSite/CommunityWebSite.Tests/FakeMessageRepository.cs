using System;
using System.Collections.Generic;
using System.Linq;
using CommunityWebSite.Models;
using CommunityWebSite.Repository;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebSite.Tests {
    public class FakeMessageRepository : IMessage {

        IQueryable<Message> m;
        List<Message> messages;
        List<Member> members;
        public FakeMessageRepository() {
            members = new List<Member>() {
                new Member {MemberID = 0, FirstName = "John", LastName = "Doe", Email = "doej@gmail.com" },
                new Member {MemberID = 1, FirstName = "George", LastName = "Lucas", Email = "starwarsfan@gmail.com"},
                new Member {MemberID = 2, FirstName = "Jane", LastName = "Dee", Email = "deej@gmail.com" }
            };

            messages = new List<Message>() {
            new Message {Subject = "Test Subject omicron", Body = "blah blah blah", Date = new DateTime(2017, 1, 1),
            Sender = members[0],
            Topic = "Topic A"
            },
            new Message {Subject = "Test Subject alpha", Body = "blah blah blah", Date = new DateTime(2017, 1, 31),
            Sender = members[1],
            Topic = "Topic B"

            },
            new Message {Subject = "Test Subject beta", Body = "blah blah blah", Date = new DateTime(2017, 2, 10),
            Sender = members[2],
            Topic = "Topic C"
            },
            new Message {Subject = "Test Subject omega", Body = "blah blah blah", Date = new DateTime(2016, 6, 5),
            Sender = members[0],
            Topic = "Topic A"
            },
            new Message {Subject = "Test Subject sigma", Body = "blah blah blah", Date = new DateTime(2016, 4, 1),
            Sender = members[2],
            Topic = "Topic B"
            },
            new Message {Subject = "Test Subject delta", Body = "blah blah blah", Date = new DateTime(2016, 12, 1),
            Sender = members[1],
            Topic = "Topic C"
            },
        };

        }

        public IEnumerable<Message> GetAllMessages()    {
            return messages;
        }


        public List<Message> GetMessagesByDateRange(DateTime start, DateTime end) {
            var list = messages.Where(d => d.Date >= start && d.Date <= end).ToList();
            return list;
        }

        public List<Message> GetMessagesByMember(int memberID) {
            var list = messages
                .Where(m => m.Sender.MemberID == memberID).ToList();

            return list;
        }

        public List<Message> GetMessagesByTopic(string topic) {
            var list = messages.Where(m => m.Topic == topic).ToList();

            return list;
        }

        public int Update(Message message) {
            return 0;
        }
    }
}
