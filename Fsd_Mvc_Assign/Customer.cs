using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Fsd_Mvc_Assign
{
    public class Customer
    {
    }

    public interface ICustomer
    {
        List<Models.Customer> GetList();
        void InsertCustomer(Models.Customer newCustomer);
        void ModifyCustomer(Models.Customer newCustomer);
        void DeleteCustomer(string custId);
        List<Models.Customer> SearchCustomer(string custId);
        List<Models.Customer> SearchCustomer(DateTime dob);


    }
    public enum InstanceType
    {
        Reader,
        Dataset
    }

    public static class CustomerFactory
    {
        public static ICustomer GetCustomerInstance(InstanceType type)
        {
            switch (type)
            {
                case InstanceType.Dataset:
                    return new CustomerDataSet();
                case InstanceType.Reader:
                    return new CustomerReader();
                default: return null;
            }
        }
    }

    public class CustomerReader : ICustomer
    {
        public List<Models.Customer> GetList()
        {
            var customerList = new List<Models.Customer>();
            var helper = new Helper(Helper.ConString);
            var reader = helper.GetDataReader("sp_getAllCustomers");
            while (reader.Read())
            {
                customerList.Add(new Models.Customer
                {
                    CustAddress = reader["custaddress"].ToString(),
                    CustId = reader["custid"].ToString(),
                    CustName = reader["custname"].ToString(),
                    DoB = reader["dob"].ToString(),
                    Salary = decimal.Parse(reader["salary"].ToString())
                });
            }

            return customerList;
        }

        public void InsertCustomer(Models.Customer newCustomer)
        {
            var helper = new Helper(Helper.ConString);
            var parameters = new List<IDbDataParameter>();
            parameters.Add(helper.GetParameter("@custid", newCustomer.CustId));
            parameters.Add(helper.GetParameter("@custname", newCustomer.CustName));
            parameters.Add(helper.GetParameter("@custaddress", newCustomer.CustAddress));
            parameters.Add(helper.GetParameter("@dob", newCustomer.DoB));
            parameters.Add(helper.GetParameter("@salary", newCustomer.Salary.ToString()));

            helper.ExecuteNonQuery("sp_CreateCusotmer", parameters);
        }

        public void ModifyCustomer(Models.Customer newCustomer)
        {
            var helper = new Helper(Helper.ConString);
            var parameters = new List<IDbDataParameter>();
            parameters.Add(helper.GetParameter("@custid", newCustomer.CustId));
            parameters.Add(helper.GetParameter("@custname", newCustomer.CustName));
            parameters.Add(helper.GetParameter("@custaddress", newCustomer.CustAddress));
            parameters.Add(helper.GetParameter("@dob", newCustomer.DoB));
            parameters.Add(helper.GetParameter("@salary", newCustomer.Salary.ToString()));

            helper.ExecuteNonQuery("sp_UpdateCusotmer", parameters);
        }

        public void DeleteCustomer(string custId)
        {
            var helper = new Helper(Helper.ConString);
            var parameters = new List<IDbDataParameter>();
            parameters.Add(helper.GetParameter("@custid", custId));

            helper.ExecuteNonQuery("sp_DeleteCusotmer", parameters);
        }

        public List<Models.Customer> SearchCustomer(string custId)
        {
            var helper = new Helper(Helper.ConString);
            var parameters = new List<IDbDataParameter>();
            List<Models.Customer> customerList = new List<Models.Customer>();
            parameters.Add(helper.GetParameter("@custid", custId));

            var reader = helper.GetDataReader("sp_searchCusotmer", parameters);

            while (reader.Read())
            {
                customerList.Add(new Models.Customer
                {
                    CustAddress = reader["custaddress"].ToString(),
                    CustId = reader["custid"].ToString(),
                    CustName = reader["custname"].ToString(),
                    DoB = reader["dob"].ToString(),
                    Salary = decimal.Parse(reader["salary"].ToString())
                });
            }

            return customerList;
        }

        public List<Models.Customer> SearchCustomer(DateTime dob)
        {
            var helper = new Helper(Helper.ConString);
            var parameters = new List<IDbDataParameter>();
            List<Models.Customer> customerList = new List<Models.Customer>();
            parameters.Add(helper.GetParameter("@dob", dob.ToString("MM/dd/yyyy")));

            var reader = helper.GetDataReader("sp_getCustomerByDate", parameters);

            while (reader.Read())
            {
                customerList.Add(new Models.Customer
                {
                    CustAddress = reader["custaddress"].ToString(),
                    CustId = reader["custid"].ToString(),
                    CustName = reader["custname"].ToString(),
                    DoB = reader["dob"].ToString(),
                    Salary = decimal.Parse(reader["salary"].ToString())
                });
            }

            return customerList;
        }
    }

    public class CustomerDataSet : ICustomer
    {
        public void DeleteCustomer(string custId)
        {
            var helper = new Helper(Helper.ConString);
            var customers = helper.GetDataTable("sp_getAllCustomers");
            var parameters = new List<IDbDataParameter>();
            parameters.Add(helper.GetParameter("@custid", custId));
            var selCust = (from row in customers.AsEnumerable()
                           where row.Field<string>("custid").Equals(custId, StringComparison.OrdinalIgnoreCase)
                           select row).FirstOrDefault();

            selCust.Delete();
            helper.DeleteDb("sp_DeleteCusotmer", parameters, customers);
        }

        public List<Models.Customer> GetList()
        {
            var helper = new Helper(Helper.ConString);
            var dt = helper.GetDataTable("sp_getAllCustomers");

            return (from cust in dt.AsEnumerable()
                    select new Models.Customer
                    {
                        CustAddress = cust.Field<string>("custaddress"),
                        CustId = cust.Field<string>("custid"),
                        CustName = cust.Field<string>("custname"),
                        DoB = cust.Field<string>("dob"),
                        Salary = cust.Field<decimal>("salary")
                    }).ToList();
        }

        public void InsertCustomer(Models.Customer newCustomer)
        {
            var helper = new Helper(Helper.ConString);
            var customers = helper.GetDataTable("sp_getAllCustomers");

            var newCust = customers.NewRow();

            newCust["custid"] = newCustomer.CustId;
            newCust["custname"] = newCustomer.CustName;
            newCust["custaddress"] = newCustomer.CustAddress;
            newCust["dob"] = newCustomer.DoB;
            newCust["salary"] = newCustomer.Salary;

            customers.Rows.Add(newCust);

            var parameters = new List<IDbDataParameter>();
            parameters.Add(helper.GetParameter("@custid", newCustomer.CustId));
            parameters.Add(helper.GetParameter("@custname", newCustomer.CustName));
            parameters.Add(helper.GetParameter("@custaddress", newCustomer.CustAddress));
            parameters.Add(helper.GetParameter("@dob", newCustomer.DoB));
            parameters.Add(helper.GetParameter("@salary", newCustomer.Salary.ToString()));

            helper.InsertDb("sp_CreateCusotmer", parameters, customers);
        }

        public void ModifyCustomer(Models.Customer newCustomer)
        {
            var helper = new Helper(Helper.ConString);
            var customers = helper.GetDataTable("sp_getAllCustomers");
            var selCust = (from row in customers.AsEnumerable()
                           where row.Field<string>("custid").Equals(newCustomer.CustId, StringComparison.OrdinalIgnoreCase)
                           select row).FirstOrDefault();


            selCust.BeginEdit();
            selCust["custname"] = newCustomer.CustName;
            selCust["custaddress"] = newCustomer.CustAddress;
            selCust["dob"] = newCustomer.DoB;
            selCust["salary"] = newCustomer.Salary;
            selCust.EndEdit();

            var parameters = new List<IDbDataParameter>();
            parameters.Add(helper.GetParameter("@custid", newCustomer.CustId));
            parameters.Add(helper.GetParameter("@custname", newCustomer.CustName));
            parameters.Add(helper.GetParameter("@custaddress", newCustomer.CustAddress));
            parameters.Add(helper.GetParameter("@dob", newCustomer.DoB));
            parameters.Add(helper.GetParameter("@salary", newCustomer.Salary.ToString()));

            helper.UpdateDb("sp_UpdateCusotmer", parameters, customers);
        }

        public List<Models.Customer> SearchCustomer(string custId)
        {
            var helper = new Helper(Helper.ConString);
            var customers = helper.GetDataTable("sp_getAllCustomers");
            customers.PrimaryKey = new DataColumn[] { customers.Columns["custid"] };
            var foundCustomers = customers.Rows.Find(custId);
            var custList = new List<Models.Customer>();

            if (foundCustomers != null)
            {
                custList.Add(new Models.Customer
                {
                    CustId = foundCustomers.Field<string>("custid"),
                    CustName = foundCustomers.Field<string>("custname"),
                    CustAddress = foundCustomers.Field<string>("custaddress"),
                    DoB = foundCustomers.Field<string>("dob"),
                    Salary = foundCustomers.Field<decimal>("salary")
                });
            }

            return custList;
        }

        public List<Models.Customer> SearchCustomer(DateTime dob)
        {
            var helper = new Helper(Helper.ConString);
            var customers = helper.GetDataTable("sp_getAllCustomers");
            return (from c in customers.AsEnumerable()
                    where DateTime.Compare(dob, DateTime.ParseExact(c.Field<string>("dob"), "MM/dd/yyyy", null)) < 0
                    select new Models.Customer
                    {
                        CustId = c.Field<string>("custid"),
                        CustName = c.Field<string>("custname"),
                        CustAddress = c.Field<string>("custaddress"),
                        DoB = c.Field<string>("dob"),
                        Salary = c.Field<decimal>("salary")
                    }).ToList();
        }
    }
}
