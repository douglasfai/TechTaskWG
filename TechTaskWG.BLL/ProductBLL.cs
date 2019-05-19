using System;
using System.Collections.Generic;
using TechTaskWG.DAL;
using TechTaskWG.DTO;

namespace TechTaskWG.BLL
{
    public class ProductBLL : IBaseBLL<Product>
    {
        private IBaseDAL<Product> dal;

        public ProductBLL()
        {
            try
            { 
                dal = DALLocator.GetProductDAL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Create(Product obj)
        {
            return dal.Create(obj);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }

        public List<Product> ReadAll()
        {
            try
            {
                List<Product> products = dal.ReadAll();
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem: " + ex);
            }            
        }

        public Product ReadById(int id)
        {
            try
            {
                Product product = dal.ReadById(id);
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Problem: " + ex);
            }
        }

        public string Update(Product obj)
        {
            return dal.Update(obj);
        }
    }
}
