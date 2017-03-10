using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebSite.Models;
using CommunityWebSite.Repository;

namespace CommunityWebSite.Tests {
    public class FakeMemberRepository : IMember {
        private List<Member> members = new List<Member>() {
            new Member {FirstName = "John", LastName = "Doe", Email = "doej@gmail.com" },
            new Member {FirstName = "Jane", LastName = "Dee", Email = "deej@gmail.com" },
            new Member {FirstName = "George", LastName = "Lucas", Email = "starwarsfan@gmail.com"}
        };

        public List<string> GetAllEmailAddresses(List<Member> list) {
            var emailList = members.Select(e => e.Email).ToList();
            emailList.Sort();

            return emailList;
        }

        public List<Member> GetMembersByLastNameLetter(string letter) {
            var lastNameList = members.Where(l => l.LastName.Substring(0, 1) == letter).ToList();
            lastNameList.Sort();

            return lastNameList;
        }

        public IEnumerable<Member> GetAllMembers() {
            return members;
        }

    }
}
