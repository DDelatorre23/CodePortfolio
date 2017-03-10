using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebSite.Models;

namespace CommunityWebSite.Repository
{
    public class MemberRepository : IMember {

        public ApplicationDbContext context;
        public MemberRepository(ApplicationDbContext ctx) {

            context = ctx;
        }

        // change to dictionary<LastName, Email>
        public List<string> GetAllEmailAddresses(List<Member> list) {
            var emailList = context.Members.Select(e => e.Email).ToList();
            emailList.Sort();

            return emailList;
        }

        public IEnumerable<Member> GetAllMembers() {
            return context.Members;
        }

        public List<Member> GetMembersByLastNameLetter(string letter) {
            var lastNameList = context.Members.Where(l => l.LastName.Substring(0, 1) == letter).ToList();
            lastNameList.Sort();

            return lastNameList;
        }
        
    }
}
