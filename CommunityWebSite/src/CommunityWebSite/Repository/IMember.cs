using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebSite.Models;

namespace CommunityWebSite.Repository
{
    public interface IMember
    {
        IEnumerable<Member> GetAllMembers();
        List<Member> GetMembersByLastNameLetter(string letter);
        List<string> GetAllEmailAddresses(List<Member> list);
    }
}
