using Framework.Domain;
using System;

namespace Websitet.Models
{
    public class ContactModel
    {
        public Guid Contact_Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public bool Deleted { get; set; }
        public DateTime LastUpdated { get; set; }
        public Authority Authority { get; set; }

        public ContactModel(){}
        public void PopulateModel(Contact _contact)
        {
            Contact_Id = _contact.Id;
            Forename = _contact.Forename;
            Surname = _contact.Surname;
            Telephone = _contact.Telephone;
            Mobile = _contact.Mobile;
            Email = _contact.Email;
            Department = _contact.Department;
            LastUpdated = _contact.LastUpdated;
        }
        public void PopulateDomain(Contact _contact)
        {
            _contact.Forename = Forename;
            _contact.Surname = Surname;
            _contact.Telephone = Telephone;
            _contact.Mobile = Mobile;
            _contact.Email = Email;
            _contact.Department = Department;
        }
    }
}