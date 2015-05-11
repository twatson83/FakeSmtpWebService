using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Owin;

namespace FakeSmtpWebService
{
    public class AuditConfig
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();
            app.UseWebApi(httpConfig);
            httpConfig.MapHttpAttributeRoutes();
            httpConfig.Routes.MapHttpRoute("Default", "{controller}/{action}", new { controller = "Home", action = "Index" });

            var appXmlType = httpConfig.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            httpConfig.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            var cors = new EnableCorsAttribute("*", "*", "*");
            httpConfig.EnableCors(cors);
        }
    }
}