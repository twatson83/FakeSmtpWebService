using System;
using netDumbster.smtp;

namespace FakeSmtpWebService.Models
{
    public class Server
    {
        public int Port { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public SimpleSmtpServer SmtpServer { get; set; }
    }
}