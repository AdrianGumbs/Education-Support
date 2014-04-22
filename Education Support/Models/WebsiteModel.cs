using Framework.Domain;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace Website.Models
{
    public class WebsiteModel
    {
        public IEnumerable<SelectListItem> SoftwareListItems { get; set; }

        public virtual Guid Website_Id { get; set; }
        [DisplayName("Address")]
        public virtual string Url { get; set; }
        [DisplayName("Hosted By")]
        public virtual string HostedBy { get; set; }
        [DisplayName("SSL Type")]
        public virtual string SSLType { get; set; }
        [DisplayName("SSL Expires")]
        public virtual Nullable<DateTime> SSLExpires { get; set; }
        public virtual Authority Authority { get; set; }
        public virtual Framework.Domain.Version Version { get; set; }
        public virtual Software Software { get; set; }
        public virtual Server Server { get; set; }
        public virtual IList<WebsiteLogin> WebsiteAccount { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool Deleted { get; set; }

        public WebsiteModel(){}
        public void PopulateModel(WebSite _website)
        {
            Website_Id = _website.Id;
            Url = _website.Url;
            HostedBy = _website.HostedBy;
            SSLType = _website.SSLType;
            SSLExpires = _website.SSLExpires;
            LastUpdated = _website.LastUpdated;
            Deleted = _website.Deleted;
        }
        public void PopulateDomain(WebSite _website)
        {
            _website.Url = Url;
            _website.HostedBy = HostedBy;
            _website.SSLType = SSLType;
            _website.SSLExpires = SSLExpires;
        }
        public void LoadSoftware(ISoftwareRepo _softwareRepo)
        {
            SoftwareListItems = GetSoftwareListItems(_softwareRepo.LoadAll());
        }
        public IEnumerable<SelectListItem> GetSoftwareListItems(IList<Software> _softwareList)
        {
            return _softwareList.Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            });
        }
    }
}