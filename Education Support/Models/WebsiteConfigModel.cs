using Framework.Domain;
using System;
using System.ComponentModel;

namespace Website.Models
{
    public class WebsiteConfigModel
    {
        public Guid Config_Id { get; set; }
        [DisplayName("Storage Path")]
        public virtual string StoragePath { get; set; }
        [DisplayName("Logs Path")]
        public virtual string LogsPath { get; set; }
        [DisplayName("Keys Path")]
        public virtual string KeysPath { get; set; }
        [DisplayName("Mail Path")]
        public virtual string MailPath { get; set; }
        [DisplayName("Mail Server")]
        public virtual string MailServer { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public WebSite Website { get; set; }

        public WebsiteConfigModel(){}
        public void PopulateModel(WebsiteConfig _config)
        {
            Config_Id = _config.Id;
            StoragePath = _config.StoragePath;
            LogsPath = _config.LogsPath;
            KeysPath = _config.KeysPath;
            MailPath = _config.MailPath;
            MailServer = _config.MailServer;
            LastUpdated = _config.LastUpdated;
        }
        public void PopulateDomain(WebsiteConfig _config)
        {
            _config.StoragePath = StoragePath;
            _config.LogsPath = LogsPath;
            _config.KeysPath = KeysPath;
            _config.MailPath = MailPath;
            _config.MailServer = MailServer;

        }
    }
}