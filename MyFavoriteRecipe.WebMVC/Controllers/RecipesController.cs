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
    public class RecipesController : Controller
    {
        // GET: Recipes
        public ActionResult Index()
        {
            var service = new RecipesList[0];
            return View(service);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipesCreate recipes)
        {
            if (!ModelState.IsValid) return View(recipes);

            var service = new RecipesService();

            if (service.CreateRecipes(recipes))
            {
                TempData["SaveResult"] = "Your reference was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Refernce could not be created.");

            return View(recipes);
        }

        public ActionResult Details(int id)
        {
            var service = new RecipesService();
            var recipe = service.GetRecipesById(id);

            return View(recipe);
        }
    }
}