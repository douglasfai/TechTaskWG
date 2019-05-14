using TechTaskWG.DTO;

namespace TechTaskWG.BLL
{
    public class BLLLocator
    {
        public static IBaseBLL<Product> GetProductBLL()
        {
            return new ProductBLL();
        }

        public static IBaseBLL<Component> GetComponentBLL()
        {
            return new ComponentBLL();
        }
    }
}
