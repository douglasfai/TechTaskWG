using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using TechTaskWG.BLL;
using TechTaskWG.DTO;

namespace TechTaskWG.Host.Controllers
{
    public class ComponentController : ApiController
    {
        private ComponentBLL componentBLL;

        public ComponentController()
        {
            componentBLL = (ComponentBLL)BLLLocator.GetComponentBLL();
        }

        public IEnumerable<Component> Get()
        {
            return componentBLL.ReadAll();
        }

        public Component Get(int Id)
        {
            return componentBLL.ReadById(Id);
        }

        public string Post([FromBody]Component component)
        {
            return componentBLL.Create(component);
        }

        public string Put(int Id, [FromBody]Component component)
        {
            return componentBLL.Update(component);
        }

        public string Delete(int Id)
        {
            return componentBLL.Delete(Id);
        }
    }
}
