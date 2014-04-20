using Framework.Domain;
using Framework.Interfaces;
using System.Collections.Generic;

namespace Website.Models.Lists
{
    public class ContactListModel : Contact
    {
        public IList<Contact> ContactList { get; set; }

        public ContactListModel(IAuthorityRepo authorityRepo, Authority authority)
        {
            this.ContactList = authorityRepo.LoadAuthorityContacts(authority);
        }
    }
}