using Framework.Domain;
using System;
using System.ComponentModel;

namespace Website.Models
{
    public class SiteModel
    {
        public virtual Guid Id { get; set; }
        [DisplayName("Address")]
        public virtual string Address_1 { get; set; }
        public virtual string Address_2 { get; set; }
        public virtual string Town { get; set; }
        public virtual string County { get; set; }
        public virtual string Postcode { get; set; }
        [DisplayName("Tel")]
        public virtual string Telephone { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual Authority Authority { get; set; }
        //carpark class

        public SiteModel(){}
        public void PopulateModel(Site _site)
        {
            Id = _site.Id;
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