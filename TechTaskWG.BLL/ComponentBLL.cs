using System;
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
            try
            {
                dal = DALLocator.GetComponentDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            try
            {
                List<Component> components = dal.ReadAll();
                return components;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem: " + ex);
            }
        }

        public Component ReadById(int id)
        {
            try
            {
                Component component = dal.ReadById(id);
                return component;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem: " + ex);
            }
        }

        public string Update(Component obj)
        {
            return dal.Update(obj);
        }
    }
}
