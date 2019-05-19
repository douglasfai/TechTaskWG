using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using TechTaskWG.BLL;
using TechTaskWG.DTO;

namespace TechTaskWG.WinService.Controllers
{
    public class ProductController : ApiController
    {
        private ProductBLL productBLL;

        public ProductController()
        {
            try
            {
                productBLL = (ProductBLL)BLLLocator.GetProductBLL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> Get()
        {
            try
            {
                return productBLL.ReadAll();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product Get(int Id)
        {
            try
            {
                return productBLL.ReadById(Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Post([FromBody]Product product)
        {
            return productBLL.Create(product);
        }

        public string Put([FromBody]Product product)
        {
            return productBLL.Update(product);
        }

        public string Delete(int Id)
        {
            return productBLL.Delete(Id);
        }
    }
}
