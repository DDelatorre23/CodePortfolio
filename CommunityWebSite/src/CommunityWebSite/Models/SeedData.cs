using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CommunityWebSite.Models {
    public class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            if (!context.Messages.Any()) {

                var member = new Member { FirstName = "John", LastName = "Doe", Email = "doej@gmail.com" };
                context.Members.Add(member);
                var message = new Message {
                    Subject = "Test Subject omicron", Body = "blah blah blah", Date = new DateTime(2017, 1, 1),
                    Sender = member,
                    Topic = "Topic A"
                };
                context.Messages.Add(message);

                message = new Message {
                    Subject = "Test Subject omega", Body = "blah blah blah", Date = new DateTime(2016, 6, 5),
                    Sender = member,
                    Topic = "Topic A"
                };
                context.Messages.Add(message);

                member = new Member { FirstName = "George", LastName = "Lucas", Email = "starwarsfan@gmail.com" };
                context.Members.Add(member);

                message = new Message {
                    Subject = "Test Subject alpha", Body = "blah blah blah", Date = new DateTime(2017, 1, 31),
                    Sender = member,
                    Topic = "Topic B"

                };
                context.Messages.Add(message);

                message = new Message {
                    Subject = "Test Subject delta", Body = "blah blah blah", Date = new DateTime(2016, 12, 1),
                    Sender = member,
                    Topic = "Topic C"
                };
                context.Messages.Add(message);

                member = new Member { FirstName = "Jane", LastName = "Dee", Email = "deej@gmail.com" };
                context.Members.Add(member);

                message = new Message {
                    Subject = "Test Subject beta", Body = "blah blah blah", Date = new DateTime(2017, 2, 10),
                    Sender = member,
                    Topic = "Topic C"
                };
                context.Messages.Add(message);
                message = new Message {
                    Subject = "Test Subject sigma", Body = "blah blah blah", Date = new DateTime(2016, 4, 1),
                    Sender = member,
                    Topic = "Topic B"
                };
                context.Messages.Add(message);
            }
            context.SaveChanges();
        }
    }
}
