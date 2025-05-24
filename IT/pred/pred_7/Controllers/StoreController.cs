using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            //return View();
            //return HttpNotFound(); 
            //return new EmptyResult();
            //return Content("Store.Index()");
            return RedirectToAction("Index", "Home", new {param1="hello", param2="MVC"});
        }
        public string Browse()
        {
            return "Hello from Store.Browse()";
        }

        [Route("store/details/{artistId:range(1,5)}/{artistAlbum:regex(\\w*\\d{4})}")] //0 ili pojke bukvi, tocno 4 brojki
        public string Details(int? artistId, string artistAlbum)
        {
            string message = "Store.Details, ID = " + artistId + " album = " + artistAlbum;
            return message;
        }
        public string Details(int? id)
        {
            string message = "Store.Details, ID = " + id;
            return message;
        }
    }
}
