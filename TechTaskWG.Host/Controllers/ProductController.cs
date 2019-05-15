using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using TechTaskWG.BLL;
using TechTaskWG.DTO;

namespace TechTaskWG.Host.Controllers
{
    public class ProductController : ApiController
    {
        private ProductBLL productBLL;

        public ProductController()
        {
            productBLL = (ProductBLL)BLLLocator.GetProductBLL();
        }

        public IEnumerable<Product> Get()
        {
            return productBLL.ReadAll();
        }

        public Product Get(int Id)
        {
            return productBLL.ReadById(Id);
        }

        public string Post([FromBody]Product product)
        {
            return productBLL.Create(product);
        }

        public string Put(int Id, [FromBody]Product product)
        {
            return productBLL.Update(product);
        }

        public string Delete(int Id)
        {
            return productBLL.Delete(Id);
        }
    }
}
