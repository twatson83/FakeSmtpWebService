﻿using System;
using System.Linq;
using System.Web.Http;

namespace FakeSmtpWebService.Controllers
{
    public class EmailController: ApiController
    {
        [AcceptVerbs("DELETE")]
        [Route("emails")]
        public void ClearEmails(int port)
        {
            SmtpServerInstance.Servers[port].SmtpServer.ClearReceivedEmail();
        }

        [AcceptVerbs("GET")]
        [Route("emails")]
        public dynamic GetEmails(int port)
        {
            return SmtpServerInstance.Servers[port].SmtpServer.ReceivedEmail.Select(x => new
            {
                FromAddress = x.FromAddress.Address,
                x.Headers,
                x.Importance,
                x.Priority,
                ToAddresses = x.ToAddresses.Select(y => y.Address ),
                Body = x.MessageParts[0].BodyData 
            });
        }

        [AcceptVerbs("GET")]
        [Route("emails/count")]
        public Int32 GetCount(int port)
        {
            return SmtpServerInstance.Servers[port].SmtpServer.ReceivedEmailCount;
        }
    }
}