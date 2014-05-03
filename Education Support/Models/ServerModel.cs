using Framework.Domain;
using System;
using System.ComponentModel;

namespace Website.Models
{
    public class ServerModel
    {
        public Guid Server_Id { get; set; }
        public string OS { get; set; }
        public string Host { get; set; }
        public string IP { get; set; }
        [DisplayName("Database")]
        public string DataSource { get; set; }
        public string Contact { get; set; }
        [DisplayName("OS")]
        public string IIS_OS { get; set; }
        [DisplayName("Host")]
        public string IIS_Host { get; set; }
        [DisplayName("IP")]
        public string IIS_IP { get; set; }
        [DisplayName("Contact")]
        public string IIS_Contact { get; set; }
        [DisplayName("Stand-alone Server")]
        public bool SingleServer { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public WebSite Website { get; set; }

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