using System.Web.Mvc;

namespace Fsd_Mvc_Assign.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var product = new Data();
            var products = product.GetProducts();
            return View(products);
        }        
    }
}
