using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebshopProject.Models;

namespace WebshopProject.Controllers
{
    
    public class HomeController : Controller
    {
        MoviesDatabaseEntities db = new MoviesDatabaseEntities();
        // GET: Home/Index
        public ActionResult Index()
        {
            //My idea is we will use this standard MVC model on index.cshtml, and AngularJS data in product views
           

            return View();
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            //Code for search results
          

            return View();
        }

        public ActionResult Type()
        {
            var model = from movie in db.Movies
                        select movie;
            return View(model.ToList());
        }
    }
}