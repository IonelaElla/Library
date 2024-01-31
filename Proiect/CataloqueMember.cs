using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
    class CataloqueMember : ListElem<Member, string>
    {
        private static CataloqueMember singleton;
        private CataloqueMember() { }
        public static CataloqueMember Instance()
        {
            if (singleton == null)
                singleton = new CataloqueMember();
            return singleton;
        }

        public bool AddMember(Member member)
        {
            return base.Add(member, member.id);

        }

        public Member SearchMember(string id)
        {
            return base.Search(id);
        }

        public List<Member> GetMembri()
        {
            return base.GetElemList();
        }

        public string ShowMembersCatalogue()
        {
            string catalog = "";
            foreach (Member member in GetMembri())
            {
                catalog += member.ToString();
            }
            return catalog;
        }
    }
}
