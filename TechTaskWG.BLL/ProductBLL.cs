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
            dal = DALLocator.GetProductDAL();
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
            return dal.ReadAll();
        }

        public Product ReadById(int id)
        {
            return dal.ReadById(id);
        }

        public string Update(Product obj)
        {
            return dal.Update(obj);
        }
    }
}
