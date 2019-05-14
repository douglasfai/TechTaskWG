using System.Collections.Generic;
using TechTaskWG.DAL;
using TechTaskWG.DTO;

namespace TechTaskWG.BLL
{
    public class ComponentBLL : IBaseBLL<Component>
    {
        private IBaseDAL<Component> dal;

        public ComponentBLL()
        {
            dal = DALLocator.GetComponentDAL();
        }

        public string Create(Component obj)
        {
            return dal.Create(obj);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }

        public List<Component> ReadAll()
        {
            return dal.ReadAll();
        }

        public Component ReadById(int id)
        {
            return dal.ReadById(id);
        }

        public string Update(Component obj)
        {
            return dal.Update(obj);
        }
    }
}
