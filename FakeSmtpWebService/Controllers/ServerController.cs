using System.Web.Http;
using FakeSmtpWebService.ViewModels;

namespace FakeSmtpWebService.Controllers
{
    public class ServerController : ApiController
    {
        [AcceptVerbs("GET")]
        [Route("server")]
        public dynamic GetServer(int port)
        {
            var server = SmtpServerInstance.Servers[port];

            return new
            {
                server.Name,
                server.Port,
                server.Created
            };
        }

        [AcceptVerbs("GET")]
        [Route("server/exists")]
        public bool Exists(int port)
        {
            return SmtpServerInstance.Servers.ContainsKey(port);
        }

        [AcceptVerbs("POST")]
        [Route("server")]
        public void CreateServer(ServerViewModel model)
        {
            SmtpServerInstance.AddServer(model.Name, model.Port);
        }

        [AcceptVerbs("Delete")]
        [Route("server")]
        public void DeleteServer(int port)
        {
            SmtpServerInstance.RemoveServer(port);
        }
    }
}