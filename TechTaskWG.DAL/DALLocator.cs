using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTaskWG.DTO;

namespace TechTaskWG.DAL
{
    public class DALLocator
    {
        public static IBaseDAL<Product> GetProductDAL()
        {
            return new ProductDAL();
        }

        public static IBaseDAL<Component> GetComponentDAL()
        {
            return new ComponentDAL();
        }
    }
}
