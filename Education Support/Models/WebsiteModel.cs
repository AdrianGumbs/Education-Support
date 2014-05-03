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
        //public string SelectedSoftware { get; set; }

        public Guid Website_Id { get; set; }
        public string Url { get; set; }
        [DisplayName("Hosted By")]
        public string HostedBy { get; set; }
        [DisplayName("SSL Type")]
        public string SSLType { get; set; }
        [DisplayName("SSL Expires")]
        public Nullable<DateTime> SSLExpires { get; set; }
        public Authority Authority { get; set; }
        public Framework.Domain.Version Version { get; set; }
        public Software Software { get; set; }
        public Server Server { get; set; }
        public IList<WebsiteLogin> WebsiteAccount { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }

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