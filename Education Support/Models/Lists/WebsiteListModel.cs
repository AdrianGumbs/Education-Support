using Framework.Domain;
using Framework.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Website.Models.Lists
{
    public class WebsiteListModel : WebSite
    {
        public virtual IList<WebSite> WebsiteList { get; set; }

        public WebsiteListModel(IWebsiteRepo _websiteRepo, string search = null)
        {
            this.WebsiteList = _websiteRepo.LoadAll();
            if (!string.IsNullOrEmpty(search))
            {
                this.WebsiteList = Search(this.WebsiteList, search);
            }
        }
        public IList<WebSite> Search(IList<WebSite> results, string search)
        {
            var _query = from m in results
                         select m;
            results = _query.Where(
                                    m => m.Url.ToUpper().Contains(search.ToUpper()) ||
                                    m.HostedBy.ToUpper().Contains(search.ToUpper()) ||
                                    m.Authority.Name.ToUpper().Contains(search.ToUpper())
                ).ToList<WebSite>();
            return results;
        }
    }
}