using Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Website.Validation;

namespace Website.Models
{
    public class AuthorityModel
    {
        public Guid Authority_Id { get; set; }
        [Required(ErrorMessage = "An Authority Code is required.")]
        [IntLength(3)]
        public int Code { get; set; }
        [Required(ErrorMessage = "An Authority name is required.")]
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public DateTime LastUpdated { get; set; }
        public IList<Contact> Contacts { get; set; }
        public IList<Site> Sites { get; set; }
        public IList<Framework.Domain.Version> Versions { get; set; }
        public IList<Request> Requests { get; set; }
        public IList<Fault> Faults { get; set; }
        //public IList<Visit> Visits { get; set; }

        public AuthorityModel(){}
        public void PopulateModel(Authority _authority)
        {
            Authority_Id = _authority.Id;
            Code = _authority.Code;
            Name = _authority.Name;
            LastUpdated = _authority.LastUpdated;
        }
        public void PopulateDomain(Authority _authority)
        {
            _authority.Code = Code;
            _authority.Name = Name;
        }

    }
}