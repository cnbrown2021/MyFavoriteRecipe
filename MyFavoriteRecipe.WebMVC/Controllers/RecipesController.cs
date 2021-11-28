using MyFavoriteRecipe.Services;
using MyFavoriteRecipe.WebMVC.Models;
using MyFavoriteRecipes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFavoriteRecipe.WebMVC.Controllers
{
    [Authorize]
    public class RecipesController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Recipes
        public ActionResult Index()
        {
            var service = new RecipesService();
            var recipes = service.GetRecipes();
            return View(recipes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            DropDownList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipesCreate recipes)
        {
            if (!ModelState.IsValid)
            {
                DropDownList();
                return View(recipes);
            }

            var service = new RecipesService();
            //ViewBag.MealCategories = _db.MealCategories.Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryName }).ToList();
            //ViewBag.References = _db.References.Select(r => new SelectListItem { Value = r.ReferenceID.ToString(), Text = r.CookbookName }).ToList();

            if (service.CreateRecipes(recipes))
            {
                DropDownList();
                TempData["SaveResult"] = "Your reference was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Refernce could not be created.");

            return View(recipes);
        }

        public ActionResult Details(int id)
        {
            var service = new RecipesService();
            var recipes = service.GetRecipesById(id);

            return View(recipes);
        }

        public ActionResult Edit(int id)
        {
            DropDownList();
            var service = new RecipesService();
            var detail = service.GetRecipesById(id);
            var content = new RecipesEdit
            {
                RecipeName = detail.RecipeName,
                Ingredients = detail.Ingredients,
                CookingInstructions = detail.CookingInstructions,
                CategoryID = detail.CategoryID,
                ReferenceID = detail.ReferenceID,
            };

            return View(content);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string name, RecipesEdit recipes)
        {
            if (!ModelState.IsValid) { DropDownList(); return View(recipes); }


            var service = new RecipesService();

            if (service.UpdateRecipes(recipes))
            {
                DropDownList();
                TempData["SaveResult"] = "The recipe was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The recipe could not be updated");

            return View(recipes);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new RecipesService();
            var recipes = service.GetRecipesById(id);

            return View(recipes);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new RecipesService();

            service.DeleteRecipes(id);

            TempData["Save Result"] = "The recipe was deleted";

            return RedirectToAction("Index");
        }

        private void DropDownList()
        {
            MealCategoryDropDownList();
            ReferenceDropDownList();
        }

        private void MealCategoryDropDownList()
        {
            ViewBag.MealCategories = _db.MealCategories.Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryID + " " + c.CategoryName }).ToList();
        }

        private void ReferenceDropDownList()
        {
            ViewBag.References = _db.References.Select(r => new SelectListItem { Value = r.ReferenceID.ToString(), Text = r.ReferenceID + " " + r.CookbookName }).ToList();
        }
    }
}