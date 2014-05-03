using Framework.Domain;
using System;
using System.ComponentModel;

namespace Website.Models
{
    public class SiteModel
    {
        public Guid Site_Id { get; set; }
        [DisplayName("Address 1")]
        public string Address_1 { get; set; }
        [DisplayName("Address 2")]
        public string Address_2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Telephone { get; set; }
        public bool Deleted { get; set; }
        public DateTime LastUpdated { get; set; }
        public Authority Authority { get; set; }
        //carpark class

        public SiteModel(){}
        public void PopulateModel(Site _site)
        {
            Site_Id = _site.Id;
            Address_1 = _site.Address_1;
            Address_2 = _site.Address_2;
            Town = _site.Town;
            County = _site.County;
            Postcode = _site.Postcode;
            Telephone = _site.Telephone;
            LastUpdated = _site.LastUpdated;
        }
        public void PopulateDomain(Site _site)
        {
            _site.Address_1 = Address_1;
            _site.Address_2 = Address_2;
            _site.Town = Town;
            _site.County = County;
            _site.Postcode = Postcode;
            _site.Telephone = Telephone;
        }
    }
}