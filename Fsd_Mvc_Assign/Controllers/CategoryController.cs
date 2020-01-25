using Fsd_Mvc_Assign.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Fsd_Mvc_Assign.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Search()
        {
            var cat = new Data();
            var categoryData = cat.GetAllCategories();
            return View(new CategorySearch(GetCategories(categoryData)));
            //return View();
        }

        [HttpPost]
        public ActionResult Search(CategorySearchCriteria criteria)
        {
            var cat = new Data();
            var categoryData = cat.SearchCategories(criteria);
            return View("Search", new CategorySearch(GetCategories(categoryData)));
        }

        public ActionResult Update(int catId)
        {
            var cat = new Data();
            var categoriesData = GetCategories(cat.GetAllCategories());
            var category = (from cat1 in categoriesData
                            where cat1.Id == catId
                            select cat1).ToArray();
            return View(category[0]);
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            var invRepository = new Data();
            invRepository.UpdateCategory(category);
            var categoryData = invRepository.GetAllCategories();
            return View("Search", new CategorySearch(GetCategories(categoryData)));
        }

        private List<Category> GetCategories(DataTable dt)
        {
            var categoryList = new List<Category>();

            foreach (DataRow catRow in dt.Rows)
            {
                categoryList.Add(
                new Category
                                {
                    Id = catRow.Field<int>("Id"),
                        Code = catRow.Field<string>("Code"),
                        Division = catRow.Field<string>("Division"),
                        Region = catRow.Field<string>("Region"),
                        SupplierId = catRow.Field<int>("SupplierId"),
                        SupplierName = catRow.Field<string>("SupplierName"),
                        Name = catRow.Field<string>("Name")
                    }
                );
            }
            return categoryList;
        }
    }
}
