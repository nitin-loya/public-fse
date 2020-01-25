using System.Web.Mvc;

namespace Fsd_Mvc_Assign.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public ActionResult SuppList()
        {
            var supp = new Data();
            var suppList = supp.GetSuppliers();
            return View(suppList);            
        }        
    }
}
