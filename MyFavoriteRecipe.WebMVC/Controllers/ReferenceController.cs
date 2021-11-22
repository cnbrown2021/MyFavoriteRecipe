using MyFavoriteRecipe.Services;
using MyFavoriteRecipes.Model;
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

        // GET Create/Reference
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReferenceCreate reference)
        {
            if (!ModelState.IsValid) return View(reference);

            var service = new ReferenceService();

            if (service.CreateReference(reference))
            {
                //ViewBag.SaveResult = "Your reference was created.";
                TempData["SaveResult"] = "Your reference was created."; //Removes data after access
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Reference could not be created.");

            return View(reference);
        }

        public ActionResult Details(int id)
        {
            var service = new ReferenceService();
            var category = service.GetReferenceById(id);

            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var service = new ReferenceService();
            var detail = service.GetReferenceById(id);
            var content = new ReferenceEdit
            {
                CookbookName = detail.CookbookName,
                CookbookAuthor = detail.CookbookAuthor
            };
            return View(content);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string name, ReferenceEdit reference)
        {
            if (!ModelState.IsValid) return View(reference);

            var service = new ReferenceService();

            if (service.UpdateReference(reference))
            {
                TempData["SaveResult"] = "The reference was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The reference could not be updated.");

            return View(reference);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new ReferenceService();
            var reference = service.GetReferenceById(id);

            return View(reference);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new ReferenceService();
            service.DeleteReference(id);
            TempData["SaveResult"] = "The reference was deleted";
            return RedirectToAction("Index");
        }
    }
}