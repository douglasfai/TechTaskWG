using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.SelfHost;
using TechTaskWG.Host.Controllers;

namespace TechTaskWG.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:9011");

            config.Routes.MapHttpRoute(
                name: "Api",
                //routeTemplate: "{controller}/{action}/{id}",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            HttpSelfHostServer server = new HttpSelfHostServer(config);

            Console.WriteLine("Starting service...");
            server.OpenAsync().Wait();

            try
            {
                //Só para verificar servidor de banco de dados
                ProductController productController = new ProductController();
                ComponentController componentController = new ComponentController();
                //Só para verificar servidor de banco de dados - Fim

                Console.WriteLine("Press any key to close the service...");
                Console.ReadLine();                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service access problem: " + ex.Message + "\nPress any key to exit...");
                Console.ReadLine();                
            }
            finally
            {
                server.CloseAsync();
            }
            
        }
    }
}
