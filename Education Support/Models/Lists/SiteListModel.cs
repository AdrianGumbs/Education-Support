using Framework.Domain;
using Framework.Interfaces;
using System.Collections.Generic;

namespace Website.Models.Lists
{
    public class SiteListModel
    {
        public IList<Site> SitesList { get; private set; }

        public SiteListModel(IAuthorityRepo _authorityRepo, Authority _authority)
	    {
            this.SitesList = _authorityRepo.LoadAuthoritySites(_authority);
	    }
    }
}