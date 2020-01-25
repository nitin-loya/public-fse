using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fsd_Mvc_Assign.Entities;

namespace Fsd_Mvc_Assign.DAL
{
    interface AllInterface
    {
    }

    public interface IItemRepository
    {
        IEnumerable<ITEM> GetAllItems(bool activeOnly);
        ITEM GetItem(int id);
        void AddItem(ITEM item);
        void UpdateItem(ITEM item);
        void DeleteItem(int id);
    }

    public interface ISupplierRepository
    {
        IEnumerable<SUPPLIER> GetAllSuppliers(bool activeOnly);
        SUPPLIER GetSupplier(int id);
        void AddSupplier(SUPPLIER supplier);
        void UpdateSupplier(SUPPLIER supplier);
        void DeleteSupplier(int id);
    }

    public interface IOrderRepository
    {
        IEnumerable<PODETAIL> GetAllOrders();
        PODETAIL GetOrder(int id);
        void AddOrder(PODETAIL newOrder);
    }

}
