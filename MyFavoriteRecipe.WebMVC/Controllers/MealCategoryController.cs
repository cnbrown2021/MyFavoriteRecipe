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
    public class MealCategoryController : Controller
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();
        //private MealCategoryService CreateMealCategoryService()
        //{
            //MealCategoryService category = new MealCategoryService();
          //  return category;
        //}
        // GET: MealCategory
        public ActionResult Index()
        {
            //MealCategoryService mealCategory = CreateMealCategoryService();
            //var category = mealCategory.GetMealCategories();
            //return View(category);
            var service = new MealCategoryService();
            var category = service.GetMealCategories();
            return View(category);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // GET: Create/MealCategory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealCategoryCreate category)
        {
            if (!ModelState.IsValid) return View(category);
            
            var service = new MealCategoryService();
            
            if (service.CreateMealCategory(category))
            {
                TempData["SaveResult"] = "The Meal Category was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Category could not be created");

            return View(category);
            
        }

        // GET: Detail
        // Customer/Detail/{id}
        public ActionResult Details(int id)
        {
            var service = new MealCategoryService();
            var category = service.GetMealCategoryById(id);

            return View(category);
        }

        // UPDATE
        public ActionResult Edit(int id)
        {
            var service = new MealCategoryService();
            var detail = service.GetMealCategoryById(id);
            var content = new MealCategoryEdit
            {
                CategoryName = detail.CategoryName,
                CategoryDescription = detail.CategoryDescription
            };
            return View(content);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string name, MealCategoryEdit category)
        {
            if (!ModelState.IsValid) return View(category);

            var service = new MealCategoryService();

            if (service.UpdateMealCategory(category))
            {
                TempData["SaveResult"] = "The category was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The category could not be updated.");

            return View(category);
        }

        // DELETE
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = new MealCategoryService();
            var category = service.GetMealCategoryById(id);

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new MealCategoryService();

            service.DeleteMealCategory(id);

            TempData["SaveResult"] = "The meal category was deleted";

            return RedirectToAction("Index");
        }
    }
}
