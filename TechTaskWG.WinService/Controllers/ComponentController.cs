using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using TechTaskWG.BLL;
using TechTaskWG.DTO;

namespace TechTaskWG.WinService.Controllers
{
    public class ComponentController : ApiController
    {
        private ComponentBLL componentBLL;

        public ComponentController()
        {
            try
            {
                componentBLL = (ComponentBLL)BLLLocator.GetComponentBLL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Component> Get()
        {
            try
            {
                return componentBLL.ReadAll();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Component Get(int Id)
        {
            try
            {
                return componentBLL.ReadById(Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Post([FromBody]Component component)
        {
            return componentBLL.Create(component);
        }

        public string Put([FromBody]Component component)
        {
            return componentBLL.Update(component);
        }

        public string Delete(int Id)
        {
            return componentBLL.Delete(Id);
        }
    }
}
