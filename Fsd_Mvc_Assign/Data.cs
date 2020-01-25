using System.Data;
using Fsd_Mvc_Assign.Models;
using System.Collections.Generic;

namespace Fsd_Mvc_Assign
{
    public class Data
    {
        private Helper _dHelper;

        public Data()
        {
            _dHelper = new Helper(Helper.ConString);
        }

        public DataTable GetSuppliers()
        {
            var dtSuppliers = _dHelper.GetDataTable("sp_getAllSuppliers");
            return dtSuppliers;
        }

        public DataTable GetProducts()
        {
            var dtProducts = _dHelper.GetDataTable("sp_getAllProducts");
            return dtProducts;
        }        

        public DataTable GetAllCategories()
        {
            return _dHelper.GetDataTable("sp_getAllCategories");
        }

        public DataTable SearchCategories(CategorySearchCriteria criteria)
        {
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(_dHelper.GetParameter("@catcode", criteria.CategoryCode));
            parameters.Add(_dHelper.GetParameter("@division", criteria.Division));
            parameters.Add(_dHelper.GetParameter(@"region", criteria.Region));
            parameters.Add(_dHelper.GetParameter("@supid", criteria.SupplierId));
            parameters.Add(_dHelper.GetParameter("@supname", criteria.SupplierName));

            return _dHelper.GetDataTable("sp_searchCategory", parameters);
        }

        public void UpdateCategory(Category category)
        {
            var categoryData = GetAllCategories();
            var selCategory = from row in categoryData.AsEnumerable()
                              where row.Field<int>("cat_id") == category.Id
                              select row;

            foreach (var row in selCategory)
            {
                row.BeginEdit();
                row["cat_code"] = category.Code;
                row["cat_name"] = category.Name;
                row["region"] = category.Region;
                row["division"] = category.Division;
                row.EndEdit();
            }

            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(_dHelper.GetParameter("@catcode", SqlDbType.VarChar, 50, "cat_code"));
            parameters.Add(_dHelper.GetParameter("@catname", SqlDbType.VarChar, 50, "cat_name"));
            parameters.Add(_dHelper.GetParameter("@division", SqlDbType.VarChar, 50, "division"));
            parameters.Add(_dHelper.GetParameter(@"region", SqlDbType.VarChar, 50, "region"));
            parameters.Add(_dHelper.GetParameter("@catId", SqlDbType.Int, 0, "cat_id"));

            _dHelper.UpdateDb("sp_updateCategory", parameters, categoryData);
        }
    }
}

