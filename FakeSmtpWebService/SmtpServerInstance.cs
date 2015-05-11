using System;
using System.Collections.Generic;
using FakeSmtpWebService.Models;
using FakeSmtpWebService.ViewModels;
using netDumbster.smtp;

namespace FakeSmtpWebService
{
    public static class SmtpServerInstance
    {
        public static Dictionary<int, Server> Servers;

        static SmtpServerInstance()
        {
            Servers = new Dictionary<int, Server>();
        }

        public static void AddServer(string name, int port)
        {
            if (Servers.ContainsKey(port))
            {
                throw new Exception(string.Format("Smtp already exists with name {0}", port));
            }

            var server = SimpleSmtpServer.Start(port);
            Servers[port] = new Server
            {
                Created = DateTime.UtcNow,
                Name = name,
                Port = port,
                SmtpServer = server
            };
        }

        public static void RemoveServer(int port)
        {
            if (Servers.ContainsKey(port))
            {
                Servers[port].SmtpServer.Stop();
                Servers.Remove(port);
            }
        }
    }
}