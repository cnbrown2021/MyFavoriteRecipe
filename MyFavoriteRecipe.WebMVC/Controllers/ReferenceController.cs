using MyFavoriteRecipe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFavoriteRecipe.WebMVC.Controllers
{
    [Authorize]
    public class ReferenceController : Controller
    {
        // GET: Reference
        public ActionResult Index()
        {
            var service = new ReferenceService();
            var reference = service.GetReferences();
            return View(reference);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


    }
}