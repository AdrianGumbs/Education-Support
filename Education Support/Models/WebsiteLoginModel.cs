using Framework.Domain;
using System;
using System.ComponentModel;

namespace Website.Models
{
    public class WebsiteLoginModel
    {
        public Guid Login_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [DisplayName("Memorable Word")]
        public string MemWord { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public WebSite Website { get; set; }

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