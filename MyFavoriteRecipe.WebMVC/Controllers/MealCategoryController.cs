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
            if (!ModelState.IsValid)
            {
                return View(category);
            }
                var service = new MealCategoryService();
                service.CreateMealCategory(category);
                return RedirectToAction("Index");
            
        }
    }
}
