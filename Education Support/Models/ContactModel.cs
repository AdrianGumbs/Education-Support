using Framework.Domain;
using System;

namespace Websitet.Models
{
    public class ContactModel
    {
        public virtual Guid Contact_Id { get; set; }
        public virtual string Forename { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Telephone { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Email { get; set; }
        public virtual string Department { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual Authority Authority { get; set; }

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