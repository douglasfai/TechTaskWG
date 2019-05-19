using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Web.Http;
using System.Web.Http.SelfHost;
using TechTaskWG.WinService.Controllers;

namespace TechTaskWG.WinService
{
    public partial class Service1 : ServiceBase
    {
        private HttpSelfHostServer server;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:9011");

            config.Routes.MapHttpRoute(
                name: "Api",
                //routeTemplate: "{controller}/{action}/{id}",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            server = new HttpSelfHostServer(config);

            server.OpenAsync().Wait();

            try
            {
                //Só para verificar servidor de banco de dados
                ProductController productController = new ProductController();
                ComponentController componentController = new ComponentController();
                //Só para verificar servidor de banco de dados - Fim                
            }
            catch (Exception ex)
            {
                server.CloseAsync();
            }
        }

        protected override void OnStop()
        {
            server.CloseAsync();
        }
    }
}
