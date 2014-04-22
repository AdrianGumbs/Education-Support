using Framework.Domain;
using System;
using System.ComponentModel;

namespace Website.Models
{
    public class ServerModel
    {
        public virtual Guid Server_Id { get; set; }
        public virtual string OS { get; set; }
        public virtual string Host { get; set; }
        public virtual string IP { get; set; }
        [DisplayName("Database")]
        public virtual string DataSource { get; set; }
        public virtual string Contact { get; set; }
        [DisplayName("OS")]
        public virtual string IIS_OS { get; set; }
        [DisplayName("Host")]
        public virtual string IIS_Host { get; set; }
        [DisplayName("IP")]
        public virtual string IIS_IP { get; set; }
        [DisplayName("Contact")]
        public virtual string IIS_Contact { get; set; }
        [DisplayName("Stand-alone Server")]
        public virtual bool SingleServer { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual WebSite Website { get; set; }

        public ServerModel(){}
        public void PopulateModel(Server _server)
        {
            Server_Id = _server.Id;
            OS = _server.OS;
            Host = _server.Host;
            IP = _server.IP;
            DataSource = _server.DataSource;
            Contact = _server.Contact;
            IIS_OS = _server.IIS_OS;
            IIS_Host = _server.IIS_Host;
            IIS_IP = _server.IIS_IP;
            IIS_Contact = _server.IIS_Contact;
            SingleServer = _server.SingleServer;
            LastUpdated = _server.LastUpdated;
        }
        public void PopulateDomain(Server _server)
        {
            _server.OS = OS;
            _server.Host = Host;
            _server.IP = IP;
            _server.DataSource = DataSource;
            _server.Contact = Contact;
            _server.IIS_OS = IIS_OS;
            _server.IIS_Host = IIS_Host;
            _server.IIS_IP = IIS_IP;
            _server.IIS_Contact = IIS_Contact;
        }
    }
}