using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Fsd_Mvc_Assign.Models
{
    public class CategorySearch
    {
        public CategorySearchCriteria Criteria { get; set; }
        public List<Category> CategoryList { get; set; }

        public CategorySearch()
        {
            Criteria = new CategorySearchCriteria();
        }

        public CategorySearch(List<Category> categories)
        {
            CategoryList = categories;
        }
    }

    public class CategorySearchCriteria
    {
        public string Division { get; set; }
        public string Region { get; set; }

        [Display(Name = "Supplier Id")]
        public string SupplierId { get; set; }

        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [Display(Name = "Category Code")]
        public string CategoryCode { get; set; }
    }
}