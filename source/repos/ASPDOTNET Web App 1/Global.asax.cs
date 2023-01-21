using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ASPDOTNET_Web_App_1
{
    public class MvcApplication : System.Web.HttpApplication
    {

        TracerProvider tracerProvider; 
        protected void Application_Start()
        {

            Dictionary<string, object> tags = new Dictionary<string, object>();
            tags.Add("host.name", Environment.MachineName.ToString());

            tracerProvider = Sdk.CreateTracerProviderBuilder()
               .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name).AddAttributes(tags))
               .AddAspNetInstrumentation()
               .AddSqlClientInstrumentation()
               .AddOtlpExporter(c =>
               {
                   c.Endpoint = new Uri("http://172.31.22.215:4317");
                   c.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.Grpc;
               }
               )
               .Build();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
