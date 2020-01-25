using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fsd_Mvc_Assign.Entities;

namespace Fsd_Mvc_Assign.Controllers
{
    public class ItemController : ApiController
    {
        //POPSModel _popsRepo;
        //public ItemController(POPSModel repo)
        //{
        //    _popsRepo = repo;
        //}

        //public IEnumerable<ITEM> GetAll()
        //{
        //    return _popsRepo.GetAllItems(false);
        //}

        //public IEnumerable<ITEM> GetActive()
        //{
        //    return _popsRepo.GetAllItems(true);
        //}

        //public ITEM GetItem(int id)
        //{
        //    return _popsRepo.GetItem(id);
        //}

        //[HttpPost]
        //public void Save(ITEM item)
        //{
        //    var exists = _popsRepo.GetItem(item.Id);
        //    if (exists == null)
        //        _popsRepo.AddItem(item);
        //    else
        //        _popsRepo.UpdateItem(item);
        //}

        //[HttpPost]
        //public void Exclude(ITEM item)
        //{
        //    var foundItem = _popsRepo.GetItem(item.Id);
        //    foundItem.IsActive = false;
        //    _popsRepo.UpdateItem(foundItem);
        //}

        //[HttpPost]
        //public void Include(Item item)
        //{
        //    var foundItem = _popsRepo.GetItem(item.Id);
        //    foundItem.IsActive = true;
        //    _popsRepo.UpdateItem(foundItem);
        //}
    }
}