using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CommunityWebSite.Controllers;
using CommunityWebSite.Models;
using CommunityWebSite.Repository;


namespace CommunityWebSite.Tests
{
    public class MessageTests {
        FakeMessageRepository repo;
        FakeMemberRepository memberRepo;
        MessageController controller;
        List<Message> messagesFromRepo;
        List<Member> membersFromRepo;

        public MessageTests() {
            repo = new FakeMessageRepository();
            memberRepo = new FakeMemberRepository();
            controller = new MessageController(repo);
            messagesFromRepo = repo.GetAllMessages().ToList();
            membersFromRepo = memberRepo.GetAllMembers().ToList();
        }

        [Fact]
        public void DoesGetMessages() {
            var message = controller.Index().ViewData.Model as List<Message>;
           
            for (int i = 0; i < message.Count; i++) {
                Assert.Equal(messagesFromRepo[i].Subject,
                    message[i].Subject);
                Assert.Equal(messagesFromRepo[i].Date,
                    message[i].Date);
                Assert.Equal(messagesFromRepo[i].Sender,
                    message[i].Sender);
                Assert.Equal(messagesFromRepo[i].Body,
                    message[i].Body);
                Assert.Equal(messagesFromRepo[i].Topic,
                    message[i].Topic);

            }
        }

        [Fact]
        public void DoesGetMessagesByDateRange() {
            DateTime start = new DateTime(2017, 1, 1);
            DateTime end = new DateTime(2017, 2, 10);

            var message = controller.GetMessageByDateRange(start, end).ViewData.Model as List<Message>;
            var test = messagesFromRepo.Where(d => d.Date >= start && d.Date <= d.Date).ToList();

            for (int i = 0; i < message.Count; i++) {
                Assert.Equal(message[i], test[i]);
            }


        }

        [Fact]
        public void DoesGetMessagesByMember() {
            var testMember = membersFromRepo[0];

            var messages = controller.GetMemberMessages(testMember.MemberID).ViewData.Model as List<Message>;

            Assert.Equal(messages[0].Subject, "Test Subject omicron");
            Assert.Equal(messages[1].Subject, "Test Subject omega");
        }

        [Fact]
        public void DoesGetMessagesByTopic() {
            var topic = messagesFromRepo[0].Topic;

            var messages = controller.GetMessagesByTopic(topic).ViewData.Model as List<Message>;

            Assert.Equal(messages[0].Topic, "Topic A");

        }

    }
}
