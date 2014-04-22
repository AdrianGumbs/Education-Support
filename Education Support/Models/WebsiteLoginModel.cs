using Framework.Domain;
using System;
using System.ComponentModel;

namespace Website.Models
{
    public class WebsiteLoginModel
    {
        public virtual Guid Login_Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        [DisplayName("Memorable Word")]
        public virtual string MemWord { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual WebSite Website { get; set; }

        public WebsiteLoginModel(){}
        public void PopulateModel(WebsiteLogin _login)
        {
            Login_Id = _login.Id;
            Username = _login.Username;
            Password = _login.Password;
            MemWord = _login.MemWord;
            LastUpdated = _login.LastUpdated;
        }
        public void PopulateDomain(WebsiteLogin _login)
        {
            _login.Username = Username;
            _login.Password = Password;
            _login.MemWord = MemWord;
        }
    }
}