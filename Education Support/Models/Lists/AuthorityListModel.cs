using Framework.Domain;
using Framework.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Website.Models.Lists
{
    public class AuthorityListModel : Authority
    {
        public IList<Authority> AuthorityList { get; private set; }

        public AuthorityListModel(IAuthorityRepo _authorityRepo, string search = null)
        {
            this.AuthorityList = Search(_authorityRepo.LoadAll(), search);
        }

        public IList<Authority> Search(IList<Authority> results, string search = null)
        {//work out how to make async
            if (!string.IsNullOrWhiteSpace(search))
            {
                    var _query = from m in results
                                 select m;
                    results = _query.Where(
                                            m => m.Name.ToUpper().Contains(search.ToUpper())
                                        ).ToList<Authority>();
            }
            return results;
        }
    }
}